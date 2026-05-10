using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseFieldKey(
  IParserRepository parsers
) : IParser<IAstFieldKey>
{
  private readonly ParserOne<IAstEnumValue> _parseEnumValue = parsers.ParserFor<IAstEnumValue>();

  public IResult<IAstFieldKey> Parse([NotNull] ITokenizer tokens, string label)
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

  internal static ParseFieldKey Factory(IParserRepository p) => new(p);
}
