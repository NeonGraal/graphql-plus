namespace GqlPlus.Encoding;

public class SimpleEncoderTests
  : EncoderClassTestBase<SimpleModel>
{
  protected override IEncoder<SimpleModel> Encoder { get; }
    = new SimpleEncoder();

  [Theory, RepeatData]
  public void Encode_WithBoolean_ReturnsStructuredBoolean(bool value)
    => EncodeAndCheck(SimpleModel.Bool(value), [
        value.TrueFalse()
        ]);

  [Theory, RepeatData]
  public void Encode_WithNumber_ReturnsStructuredNumber(decimal value)
    => EncodeAndCheck(SimpleModel.Num("Type", value), [
        $"!Type {value:0.#####}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithString_ReturnsStructuredString(string type, string value)
    => EncodeAndCheck(SimpleModel.Str(type, value), [
        $"!{type} '{value}'"
        ]);

  [Theory, RepeatData]
  public void Encode_WithValue_ReturnsStructuredString(string type, string value)
    => EncodeAndCheck(SimpleModel.Enum(type, value), [
        $"!{type} {value}"
        ]);
}
