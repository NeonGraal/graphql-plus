namespace GqlPlus.Encoding.Simple;

public class EnumValueEncoderTests
  : EncoderClassTestBase<EnumValueModel>
{
  protected override IEncoder<EnumValueModel> Encoder { get; }
    = new EnumValueEncoder();

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(EnumLabelInput input, string contents)
    => EncodeAndCheck(new(input.EnumType, input.Label, contents),
      TagAll("_EnumValue",
      ":description=" + contents.QuotedIdentifier(),
      ":label=" + input.Label,
      ":name=" + input.EnumType,
      ":typeKind=[_SimpleKind]Enum"));
}
