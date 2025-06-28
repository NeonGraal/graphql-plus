
namespace GqlPlus.Decoding;

public class StringDecoderTests
  : ScalarDecoderClassTestBase<string>
{
  protected override IDecoder<string> Decoder { get; }
    = new StringDecoder();

  protected override string? ExpectedBool(bool value) => value.TrueFalse();
  protected override string? ExpectedNumber(decimal value) => $"{value:0.#####}";
  protected override string? ExpectedText(string value) => value;
  protected override string? ExpectedList(string value) => value;
  protected override string? ExpectedDict(string key, string value) => null;
}
