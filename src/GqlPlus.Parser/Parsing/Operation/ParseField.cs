using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseField(
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpDirective>.DA directives,
  Parser<IParserArg, IGqlpArg>.D argument,
  Parser<IGqlpSelection>.DA objectParser
) : Parser<IGqlpField>.I
{
  private readonly Parser<IGqlpModifier>.LA _modifiers = modifiers;
  private readonly Parser<IGqlpDirective>.LA _directives = directives;
  private readonly Parser<IParserArg, IGqlpArg>.L _argument = argument;
  private readonly Parser<IGqlpSelection>.LA _object = objectParser;

  public IResult<IGqlpField> Parse(ITokenizer tokens, string label)

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

    _argument.I.Parse(tokens, "Arg").Required(argument => result.Arg = argument);

    IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => result.Modifiers = [.. value])) {
      return modifiers.AsPartial<IGqlpField>(result);
    }

    IResultArray<IGqlpDirective> directives = _directives.Parse(tokens, label);
    if (!directives.Optional(value => result.Directives = [.. value])) {
      return directives.AsPartial<IGqlpField>(result);
    }

    IResultArray<IGqlpSelection> selections = _object.Parse(tokens, label);
    return !selections.Optional(value => result.Selections = [.. value])
      ? selections.AsPartial<IGqlpField>(result)
      : result.Ok<IGqlpField>();
  }
}
