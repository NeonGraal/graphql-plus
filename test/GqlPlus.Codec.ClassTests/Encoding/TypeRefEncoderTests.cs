namespace GqlPlus.Encoding;

public class TypeRefEncoderTests
  : EncoderClassTestBase<TypeRefModel<TypeKindModel>>
{
  protected override IEncoder<TypeRefModel<TypeKindModel>> Encoder { get; }
    = new TypeRefEncoder<TypeRefModel<TypeKindModel>, TypeKindModel>();

  [Theory, RepeatData]
  public void Encode_WithAll_ReturnsExpected(TypeKindModel typeKind, string name, string description)
  {
    // Arrange
    EncodeAndCheck(new TypeRefModel<TypeKindModel>(typeKind, name, description), [
        "!_TypeRef(_TypeKind)",
        "description: " + description.Quoted("'"),
        "name: "  + name,
        $"typeKind: !_TypeKind {typeKind}"
      ]);
  }
}
