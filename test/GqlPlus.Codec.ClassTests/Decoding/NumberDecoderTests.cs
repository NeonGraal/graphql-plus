
namespace GqlPlus.Decoding;

public class NumberDecoderTests
  : ScalarDecoderClassTestBase<decimal?, decimal>
{
  protected override IDecoder<decimal?> Decoder { get; }
    = new NumberDecoder();

  protected override decimal? ExpectedBool(bool value) => value ? 1m : 0m;
  protected override decimal? ExpectedNumber(decimal value) => value;
  protected override decimal? ExpectedText(string value)
    => decimal.TryParse(value, out decimal result) ? result : null;
  protected override decimal? ExpectedList(decimal value) => value;
  protected override decimal? ExpectedDict(string key, decimal value) => null;
  protected override Structured Value(decimal value) => new(value);
}
