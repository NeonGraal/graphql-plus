namespace GqlPlus.Encoding.Objects;

public class TypeOutputEncoderTests
  : TypeObjectEncoderBase<TypeOutputModel, ObjBaseModel, OutputFieldModel, ObjAlternateModel>
{
  public TypeOutputEncoderTests()
    => Encoder = new TypeOutputEncoder(new(ObjBase, Field, ObjField, DualField, Alternate, ObjAlternate, DualAlternate, TypeParam));

  protected override IEncoder<TypeOutputModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string contents)
    => EncodeAndCheck(new(name, contents), [
      "!_TypeOutput",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Output"
      ]);
}
