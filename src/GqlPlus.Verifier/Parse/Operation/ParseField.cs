using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseField : Parser<FieldAst>.I
{
  private readonly Parser<ModifierAst>.LA _modifiers;
  private readonly Parser<DirectiveAst>.LA _directives;
  private readonly Parser<IParserArgument, ArgumentAst>.L _argument;
  private readonly Parser<IAstSelection>.LA _object;

  public ParseField(
    Parser<ModifierAst>.DA modifiers,
    Parser<DirectiveAst>.DA directives,
    Parser<IParserArgument, ArgumentAst>.D argument,
    Parser<IAstSelection>.DA objectParser)
  {
    _modifiers = modifiers;
    _directives = directives;
    _argument = argument;
    _object = objectParser;
  }

  public IResult<FieldAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var at = tokens.At;
    if (!tokens.Identifier(out var alias)) {
      return tokens.Error<FieldAst>(label, "initial identifier");
    }

    var result = new FieldAst(at, alias);

    if (tokens.Take(':')) {
      at = tokens.At;
      if (!tokens.Identifier(out var name)) {
        return tokens.Error<FieldAst>(label, "a name after an alias");
      }

      result = new FieldAst(at, name) { Alias = alias };
    }

    _argument.Parse(tokens, "Argument").Required(argument => result.Argument = argument);

    var modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => result.Modifiers = value)) {
      return modifiers.AsResult<FieldAst>();
    }

    _directives.Parse(tokens, label).WithResult(directives => result.Directives = directives);

    var selections = _object.Parse(tokens, label);
    return !selections.Optional(value => result.Selections = value)
      ? selections.AsResult<FieldAst>()
      : result.Ok();
  }
}
