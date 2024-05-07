using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseField(
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpDirective>.DA directives,
  Parser<IParserArgument, ArgumentAst>.D argument,
  Parser<IGqlpSelection>.DA objectParser
) : Parser<IGqlpField>.I
{
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;
  private readonly Parser<IGqlpDirective>.LA _directives = directives;
  private readonly Parser<IParserArgument, ArgumentAst>.L _argument = argument;
  private readonly Parser<IGqlpSelection>.LA _object = objectParser;

  public IResult<IGqlpField> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    TokenAt at = tokens.At;
    if (!tokens.Identifier(out string? alias)) {
      return tokens.Error<IGqlpField>(label, "initial identifier");
    }

    FieldAst result = new(at, alias);

    if (tokens.Take(':')) {
      at = tokens.At;
      if (!tokens.Identifier(out string? name)) {
        return tokens.Error<IGqlpField>(label, "a name after an alias");
      }

      result = new FieldAst(at, name) { FieldAlias = alias };
    }

    _argument.I.Parse(tokens, "Argument").Required(argument => result.Argument = argument);

    IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => result.Modifiers = value.ArrayOf<ModifierAst>())) {
      return modifiers.AsResult<IGqlpField>();
    }

    _directives.Parse(tokens, label).WithResult(directives => result.Directives = [.. directives]);

    IResultArray<IGqlpSelection> selections = _object.Parse(tokens, label);
    return !selections.Optional(value => result.Selections = [.. value])
      ? selections.AsResult<IGqlpField>()
      : result.Ok<IGqlpField>();
  }
}
