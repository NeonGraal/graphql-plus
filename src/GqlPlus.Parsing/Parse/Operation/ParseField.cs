using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal class ParseField(
  Parser<ModifierAst>.DA modifiers,
  Parser<DirectiveAst>.DA directives,
  Parser<IParserArgument, ArgumentAst>.D argument,
  Parser<IAstSelection>.DA objectParser
) : Parser<FieldAst>.I
{
  private readonly Parser<ModifierAst>.LA _modifiers = modifiers;
  private readonly Parser<DirectiveAst>.LA _directives = directives;
  private readonly Parser<IParserArgument, ArgumentAst>.L _argument = argument;
  private readonly Parser<IAstSelection>.LA _object = objectParser;

  public IResult<FieldAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    TokenAt at = tokens.At;
    if (!tokens.Identifier(out string? alias)) {
      return tokens.Error<FieldAst>(label, "initial identifier");
    }

    FieldAst result = new(at, alias);

    if (tokens.Take(':')) {
      at = tokens.At;
      if (!tokens.Identifier(out string? name)) {
        return tokens.Error<FieldAst>(label, "a name after an alias");
      }

      result = new FieldAst(at, name) { Alias = alias };
    }

    _argument.I.Parse(tokens, "Argument").Required(argument => result.Argument = argument);

    IResultArray<ModifierAst> modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => result.Modifiers = value)) {
      return modifiers.AsResult<FieldAst>();
    }

    _directives.Parse(tokens, label).WithResult(directives => result.Directives = directives);

    IResultArray<IAstSelection> selections = _object.Parse(tokens, label);
    return !selections.Optional(value => result.Selections = value)
      ? selections.AsResult<FieldAst>()
      : result.Ok();
  }
}
