using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseOperation(
  Parser<IParserArg, IGqlpArg>.D argument,
  Parser<IGqlpDirective>.DA directives,
  ParserArray<IParserStartFragments, IGqlpFragment>.DA startFragments,
  ParserArray<IParserEndFragments, IGqlpFragment>.DA endFragments,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpSelection>.DA objectParser,
  Parser<IGqlpVariable>.DA variables
) : Parser<IGqlpOperation>.I
{
  private readonly Parser<IParserArg, IGqlpArg>.L _argument = argument;
  private readonly Parser<IGqlpDirective>.LA _directives = directives;
  private readonly ParserArray<IParserStartFragments, IGqlpFragment>.LA _startFragments = startFragments;
  private readonly ParserArray<IParserEndFragments, IGqlpFragment>.LA _endFragments = endFragments;
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;
  private readonly Parser<IGqlpSelection>.LA _object = objectParser;
  private readonly Parser<IGqlpVariable>.LA _variables = variables;

  public IResult<IGqlpOperation> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    if (tokens.AtStart) {
      if (!tokens.Read()) {
        return tokens.Error<IGqlpOperation>(label, "text");
      }
    }

    OperationAst ast = ParseCategory(tokens);

    IResultArray<IGqlpVariable> variables = _variables.Parse(tokens, label);
    if (!variables.Optional(value => ast.Variables = [.. value])) {
      return variables.AsPartial(Final());
    }

    _directives.Parse(tokens, label).Required(directives => ast.Directives = [.. directives]);

    _startFragments.I.Parse(tokens, label).WithResult(value => ast.Fragments = [.. value]);
    if (!tokens.Prefix(':', out string? result, out _)) {
      return tokens.Partial(label, "identifier to follow ':'", Final);
    }

    if (result is not null) {
      ast.ResultType = result;
      IResult<IGqlpArg> argument = _argument.I.Parse(tokens, "Arg");
      if (!argument.Optional(value => ast.Arg = (ArgAst?)value)) {
        return argument.AsPartial(Final());
      }
    } else if (!_object.Parse(tokens, label).Required(selections => ast.ResultObject = [.. selections])) {
      return tokens.Partial(label, "Object or Type", Final);
    }

    IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, label);

    if (modifiers.IsError()) {
      return modifiers.AsPartial(Final());
    }

    modifiers.WithResult(value => ast.Modifiers = value.ArrayOf<ModifierAst>());
    _endFragments.I.Parse(tokens, label).WithResult(value =>
      ast.Fragments = [.. ast.Fragments.Concat(value)]);

    if (tokens.AtEnd) {
      ast.Result = ParseResultKind.Success;
    } else {
      return tokens.Partial(label, "no more text", Final);
    }

    return Final().Ok();

    IGqlpOperation Final()
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
    TokenAt at = tokens.At;
    return tokens.Identifier(out string? category)
      ? tokens.Identifier(out string? name)
        ? new(at, name) { Category = category }
        : new(at) { Category = category }
      : new(at);
  }
}
