namespace GqlPlus.Encoding.Simple;

public class EnumLabelEncoderTests : EncoderClassTestBase<EnumLabelModel>
{
  protected override IEncoder<EnumLabelModel> Encoder { get; }
    = new EnumLabelEncoder();

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string ofEnum, string contents)
    => EncodeAndCheck(new(name, ofEnum, contents),
      TagAll("_EnumLabel",
      ":description=" + contents.QuotedIdentifier(),
      ":enum=" + ofEnum,
      ":name=" + name));
}
