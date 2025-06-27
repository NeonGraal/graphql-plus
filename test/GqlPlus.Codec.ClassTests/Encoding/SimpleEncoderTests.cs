namespace GqlPlus.Encoding;

public class SimpleEncoderTests
  : EncoderClassTestBase<SimpleModel>
{
  protected override IEncoder<SimpleModel> Encoder { get; }
    = new SimpleEncoder();

  [Theory, RepeatData]
  public void Encode_WithBoolean_ReturnsStructuredBoolean(bool value)
    => EncodeAndCheck(SimpleModel.Bool("", value), [
        value.TrueFalse()
        ]);

  [Theory, RepeatData]
  public void Encode_WithTypedBoolean_ReturnsStructuredBoolean(string type, bool value)
    => EncodeAndCheck(SimpleModel.Bool(type, value), [
        $"!{type} {value.TrueFalse()}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithNumber_ReturnsStructuredNumber(decimal value)
    => EncodeAndCheck(SimpleModel.Num("", value), [
        $"{value:0.#####}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithTypedNumber_ReturnsStructuredNumber(string type, decimal value)
    => EncodeAndCheck(SimpleModel.Num(type, value), [
        $"!{type} {value:0.#####}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithString_ReturnsStructuredString(string value)
    => EncodeAndCheck(SimpleModel.Str("", value), [
        $"'{value}'"
        ]);

  [Theory, RepeatData]
  public void Encode_WithTypedString_ReturnsStructuredString(string type, string value)
    => EncodeAndCheck(SimpleModel.Str(type, value), [
        $"!{type} '{value}'"
        ]);

  [Theory, RepeatData]
  public void Encode_WithValue_ReturnsStructuredString(string value)
    => EncodeAndCheck(SimpleModel.Enum("", value), [
        value
        ]);

  [Theory, RepeatData]
  public void Encode_WithTypedValue_ReturnsStructuredString(string type, string value)
    => EncodeAndCheck(SimpleModel.Enum(type, value), [
        $"!{type} {value}"
        ]);
}
