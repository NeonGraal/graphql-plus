namespace GqlPlus.Encoding.Objects;

public class TypeOutputEncoderTests
  : TypeObjectEncoderBase<TypeOutputModel, ObjBaseModel, OutputFieldModel, AlternateModel>
{
  public TypeOutputEncoderTests()
    => Encoder = new TypeOutputEncoder(Encoders);

  protected override IEncoder<TypeOutputModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string contents)
    => EncodeAndCheck(new(name, contents),
      TagAll("_TypeOutput",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + name,
      ":typeKind=[_TypeKind]Output"));
}
