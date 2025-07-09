namespace GqlPlus.Encoding.Objects;

public class OutputEnumEncoderTests
  : EncoderClassTestBase<OutputEnumModel>
{
  protected override IEncoder<OutputEnumModel> Encoder { get; }
    = new OutputEnumEncoder();

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string field, string enumType, string enumLabel, string contents)
    => EncodeAndCheck(new(field, enumType, enumLabel, contents), [
      "!_OutputEnum",
      "description: " + contents.Quoted("'"),
      "field: " + field,
      "label: " + enumLabel,
      "typeKind: !_SimpleKind Enum",
      "typeName: " + enumType
    ]);
}
