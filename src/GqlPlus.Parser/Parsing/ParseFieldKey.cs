using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseFieldKey(
  IParserRepository parsers
) : Parser<IGqlpFieldKey>.I
{
  private readonly Parser<IGqlpEnumValue>.L _parseEnumValue = parsers.ParserFor<IGqlpEnumValue>();

  public IResult<IGqlpFieldKey> Parse(ITokenizer tokens, string label)
  {
    TokenAt at = tokens.At;
    if (tokens.Number(out decimal number)) {
      return new FieldKeyAst(at, number).Ok<IGqlpFieldKey>();
    }

    if (tokens.String(out string? contents)) {
      return new FieldKeyAst(at, contents).Ok<IGqlpFieldKey>();
    }

    IResult<IGqlpEnumValue> enumResult = _parseEnumValue.Parse(tokens, label);
    return enumResult.SelectOk(e => new FieldKeyAst(e) as IGqlpFieldKey);
  }
}
