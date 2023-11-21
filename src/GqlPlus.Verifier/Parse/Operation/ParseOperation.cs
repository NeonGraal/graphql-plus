using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseOperation : IParser<OperationAst>
{
  private readonly IParserArgument _argument;
  private readonly IParserArray<DirectiveAst> _directives;
  private readonly IParserStartFragments _startFragments;
  private readonly IParserEndFragments _endFragments;
  private readonly IParserArray<ModifierAst> _modifiers;
  private readonly IParserArray<IAstSelection> _object;
  private readonly IParserArray<VariableAst> _variables;

  public ParseOperation(
    IParserArgument argument,
    IParserArray<DirectiveAst> directives,
    IParserStartFragments startFragments,
    IParserEndFragments endFragments,
    IParserArray<ModifierAst> modifiers,
    IParserArray<IAstSelection> objectParser,
    IParserArray<VariableAst> variables)
  {
    _argument = argument.ThrowIfNull();
    _directives = directives.ThrowIfNull();
    _startFragments = startFragments.ThrowIfNull();
    _endFragments = endFragments.ThrowIfNull();
    _modifiers = modifiers.ThrowIfNull();
    _object = objectParser.ThrowIfNull();
    _variables = variables.ThrowIfNull();
  }

  public IResult<OperationAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    if (tokens.AtStart) {
      if (!tokens.Read()) {
        return tokens.Error<OperationAst>("Operation", "text");
      }
    }

    var at = tokens.At;
    OperationAst ast = new(at);
    if (tokens.Identifier(out var category)) {
      if (tokens.Identifier(out var name)) {
        ast = new(at, name) { Category = category };
      } else {
        ast.Category = category;
      }
    }

    var variables = _variables.Parse(tokens);
    if (!variables.Optional(value => ast.Variables = value)) {
      return variables.AsPartial(Final());
    }

    _directives.Parse(tokens).Required(directives => ast.Directives = directives);

    _startFragments.Parse(tokens).WithResult(value => ast.Fragments = value);
    if (!tokens.Prefix(':', out var result, out _)) {
      return tokens.Partial("Operation", "identifier to follow ':'", Final);
    }

    if (result is not null) {
      ast.ResultType = result;
      var argument = _argument.Parse(tokens);
      if (!argument.Optional(value => ast.Argument = value)) {
        return argument.AsPartial(Final());
      }
    } else if (!_object.Parse(tokens).Required(selections => ast.Object = selections)) {
      return tokens.Partial("Operation", "Object or Type", Final);
    }

    var modifiers = _modifiers.Parse(tokens);

    if (modifiers.IsError()) {
      return modifiers.AsPartial(Final());
    }

    modifiers.WithResult(value => ast.Modifiers = value);
    _endFragments.Parse(tokens).WithResult(value =>
      ast.Fragments = ast.Fragments.Concat(value).ToArray());

    if (tokens.AtEnd) {
      ast.Result = ParseResultKind.Success;
    } else {
      return tokens.Partial("Operation", "no more text", Final);
    }

    return Final().Ok();

    OperationAst Final()
      => tokens is OperationContext context
          ? ast with {
            Errors = tokens.Errors.ToArray(),
            Usages = context.Variables.ToArray(),
            Spreads = context.Spreads.ToArray(),
          }
          : ast with { Errors = tokens.Errors.ToArray(), };
  }
}
