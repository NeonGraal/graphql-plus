using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseFieldKey(
  IParserRepository parsers
) : Parser<IAstFieldKey>.I
{
  private readonly Parser<IAstEnumValue>.L _parseEnumValue = parsers.ParserFor<IAstEnumValue>();

  public IResult<IAstFieldKey> Parse(ITokenizer tokens, string label)
  {
    TokenAt at = tokens.At;
    if (tokens.Number(out decimal number)) {
      return new FieldKeyAst(at, number).Ok<IAstFieldKey>();
    }

    if (tokens.String(out string? contents)) {
      return new FieldKeyAst(at, contents).Ok<IAstFieldKey>();
    }

    IResult<IAstEnumValue> enumResult = _parseEnumValue.Parse(tokens, label);
    return enumResult.SelectOk(e => new FieldKeyAst(e) as IAstFieldKey);
  }
}
