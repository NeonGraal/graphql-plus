using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseFieldKey
  : Parser<IGqlpFieldKey>.I
{
  public IResult<IGqlpFieldKey> Parse(ITokenizer tokens, string label)

  {
    TokenAt at = tokens.At;
    if (tokens.Number(out decimal number)) {
      return new FieldKeyAst(at, number).Ok<IGqlpFieldKey>();
    }

    if (tokens.String(out string? contents)) {
      return new FieldKeyAst(at, contents).Ok<IGqlpFieldKey>();
    }

    if (tokens.Identifier(out string? enumType)) {
      if (tokens.Take('.')) {
        return tokens.Identifier(out string? enumLabel)
          ? new FieldKeyAst(at, enumType, enumLabel).Ok<IGqlpFieldKey>()
          : tokens.Error<IGqlpFieldKey>(label, "enum value after '.'");
      }

      string type = BuiltIn.EnumValues.GetValueOrDefault(enumType, "");
      return new FieldKeyAst(at, type, enumType).Ok<IGqlpFieldKey>();
    }

    return 0.Empty<IGqlpFieldKey>();
  }
}
