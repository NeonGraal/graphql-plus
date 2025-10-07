using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseEnumValue
  : Parser<IGqlpEnumValue>.I
{
  public IResult<IGqlpEnumValue> Parse(ITokenizer tokens, string label)
  {
    TokenAt at = tokens.At;

    if (tokens.Identifier(out string? enumType)) {
      if (tokens.Take('.')) {
        return tokens.Identifier(out string? enumLabel)
          ? new EnumValueAst(at, enumType, enumLabel).Ok<IGqlpEnumValue>()
          : tokens.Error<IGqlpEnumValue>(label, "enum value after '.'");
      }

      // Check for built-in enum values - if found, create with type and label
      if (BuiltIn.EnumValues.TryGetValue(enumType, out string? builtInType)) {
        return new EnumValueAst(at, builtInType, enumType).Ok<IGqlpEnumValue>();
      }

      // For regular enum labels without type, create with just the label
      return new EnumValueAst(at, enumType).Ok<IGqlpEnumValue>();
    }

    return 0.Empty<IGqlpEnumValue>();
  }
}
