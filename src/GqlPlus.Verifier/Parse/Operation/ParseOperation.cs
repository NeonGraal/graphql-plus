﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseOperation(
  Parser<IParserArgument, ArgumentAst>.D argument,
  Parser<DirectiveAst>.DA directives,
  ParserArray<IParserStartFragments, FragmentAst>.DA startFragments,
  ParserArray<IParserEndFragments, FragmentAst>.DA endFragments,
  Parser<ModifierAst>.DA modifiers,
  Parser<IAstSelection>.DA objectParser,
  Parser<VariableAst>.DA variables
) : Parser<OperationAst>.I
{
  private readonly Parser<IParserArgument, ArgumentAst>.L _argument = argument;
  private readonly Parser<DirectiveAst>.LA _directives = directives;
  private readonly ParserArray<IParserStartFragments, FragmentAst>.LA _startFragments = startFragments;
  private readonly ParserArray<IParserEndFragments, FragmentAst>.LA _endFragments = endFragments;
  private readonly Parser<ModifierAst>.LA _modifiers = modifiers;
  private readonly Parser<IAstSelection>.LA _object = objectParser;
  private readonly Parser<VariableAst>.LA _variables = variables;

  public IResult<OperationAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.AtStart) {
      if (!tokens.Read()) {
        return tokens.Error<OperationAst>(label, "text");
      }
    }

    OperationAst ast = ParseCategory(tokens);

    var variables = _variables.Parse(tokens, label);
    if (!variables.Optional(value => ast.Variables = value)) {
      return variables.AsPartial(Final());
    }

    _directives.Parse(tokens, label).Required(directives => ast.Directives = directives);

    _startFragments.I.Parse(tokens, label).WithResult(value => ast.Fragments = value);
    if (!tokens.Prefix(':', out var result, out _)) {
      return tokens.Partial(label, "identifier to follow ':'", Final);
    }

    if (result is not null) {
      ast.ResultType = result;
      var argument = _argument.I.Parse(tokens, "Argument");
      if (!argument.Optional(value => ast.Argument = value)) {
        return argument.AsPartial(Final());
      }
    } else if (!_object.Parse(tokens, label).Required(selections => ast.Object = selections)) {
      return tokens.Partial(label, "Object or Type", Final);
    }

    var modifiers = _modifiers.Parse(tokens, label);

    if (modifiers.IsError()) {
      return modifiers.AsPartial(Final());
    }

    modifiers.WithResult(value => ast.Modifiers = value);
    _endFragments.I.Parse(tokens, label).WithResult(value =>
      ast.Fragments = [.. ast.Fragments.Concat(value)]);

    if (tokens.AtEnd) {
      ast.Result = ParseResultKind.Success;
    } else {
      return tokens.Partial(label, "no more text", Final);
    }

    return Final().Ok();

    OperationAst Final()
      => tokens is OperationContext context
          ? ast with {
            Errors = tokens.Errors,
            Usages = [.. context.Variables],
            Spreads = [.. context.Spreads],
          }
          : ast with { Errors = tokens.Errors, };
  }

  private static OperationAst ParseCategory<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    return tokens.Identifier(out var category)
      ? tokens.Identifier(out var name)
        ? new(at, name) { Category = category }
        : new(at) { Category = category }
      : new(at);
  }
}
