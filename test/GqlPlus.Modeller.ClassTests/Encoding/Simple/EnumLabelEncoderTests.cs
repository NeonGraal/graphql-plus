namespace GqlPlus.Encoding.Simple;

public class EnumLabelEncoderTests : EncoderClassTestBase<EnumLabelModel>
{
  protected override IEncoder<EnumLabelModel> Encoder { get; }
    = new EnumLabelEncoder();

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string ofEnum, string contents)
    => EncodeAndCheck(new(name, ofEnum, contents), [
      "!_EnumLabel",
      "description: " + contents.Quoted("'"),
      "enum: " + ofEnum,
      "name: " + name
      ]);
}
