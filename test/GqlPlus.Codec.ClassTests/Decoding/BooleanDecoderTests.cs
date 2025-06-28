
namespace GqlPlus.Decoding;

public class BooleanDecoderTests
  : ScalarDecoderClassTestBase<bool?, bool>
{
  [Theory, InlineData(0, false), InlineData(1, true), InlineData(2, null)]
  public void Decode_Specific_Number(decimal value, bool? expected)
    => DecodeAndCheck(new(value), expected);

  [Theory, InlineData("true", true), InlineData("false", false), InlineData("", null)]
  public void Decode_Specific_Text(string value, bool? expected)
    => DecodeAndCheck(new(value), expected);

  protected override IDecoder<bool?> Decoder { get; }
    = new BooleanDecoder();

  protected override bool? ExpectedBool(bool value) => value;
  protected override bool? ExpectedNumber(decimal value)
    => value switch {
      0m => false,
      1m => true,
      _ => null
    };
  protected override bool? ExpectedText(string value)
    => value switch {
      "true" => true,
      "false" => false,
      _ => null
    };
  protected override bool? ExpectedList(bool value) => value;
  protected override bool? ExpectedDict(string key, bool value) => null;
  protected override Structured Value(bool value) => new(value);
}
