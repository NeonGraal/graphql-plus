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
  public void Encode_WithDomainBoolean_ReturnsStructuredBoolean(string domain, bool value)
    => EncodeAndCheck(SimpleModel.BoolDom(domain, value), [
        $"!{domain} {value.TrueFalse()}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithNumber_ReturnsStructuredNumber(decimal value)
    => EncodeAndCheck(SimpleModel.Num(value), [
        $"{value:0.#####}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithDomainNumber_ReturnsStructuredNumber(string domain, decimal value)
    => EncodeAndCheck(SimpleModel.NumDom(domain, value), [
        $"!{domain} {value:0.#####}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithString_ReturnsStructuredString(string value)
    => EncodeAndCheck(SimpleModel.Str(value), [
        $"'{value}'"
        ]);

  [Theory, RepeatData]
  public void Encode_WithDomainString_ReturnsStructuredString(string domain, string value)
    => EncodeAndCheck(SimpleModel.StrDom(domain, value), [
        $"!{domain} '{value}'"
        ]);

  [Theory, RepeatData]
  public void Encode_WithLabel_ReturnsStructuredString(string value)
    => EncodeAndCheck(SimpleModel.Enum(new EnumValueModel("", value, "")), [
        value
        ]);

  [Theory, RepeatData]
  public void Encode_WithTypedLabel_ReturnsStructuredString(string type, string value)
    => EncodeAndCheck(SimpleModel.Enum(new EnumValueModel(type, value, "")), [
        $"!{type} {value}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithDomainLabel_ReturnsStructuredString(string domain, string value)
    => EncodeAndCheck(SimpleModel.EnumDom(domain, "", value), [
        $"!{domain} {value}"
        ]);

  [Theory, RepeatData]
  public void Encode_WithDomainTypedLabel_ReturnsStructuredString(string domain, string type, string value)
    => EncodeAndCheck(SimpleModel.EnumDom(domain, type, value), [
        $"!{domain} {value}"
        ]);
}
