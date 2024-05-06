using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseFieldKey : Parser<FieldKeyAst>.I
{
  public IResult<FieldKeyAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    TokenAt at = tokens.At;
    if (tokens.Number(out decimal number)) {
      return new FieldKeyAst(at, number).Ok();
    }

    if (tokens.String(out string? contents)) {
      return new FieldKeyAst(at, contents).Ok();
    }

    if (tokens.Identifier(out string? enumType)) {
      if (tokens.Take('.')) {
        return tokens.Identifier(out string? enumValue)
          ? new FieldKeyAst(at, enumType, enumValue).Ok()
          : tokens.Error<FieldKeyAst>(label, "enum value after '.'");
      }

      string type = BuiltIn.EnumValues.GetValueOrDefault(enumType, "");
      return new FieldKeyAst(at, type, enumType).Ok();
    }

    return 0.Empty<FieldKeyAst>();
  }
}
