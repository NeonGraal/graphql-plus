namespace GqlPlus.Encoding.Objects;

public class TypeParamEncoderTests
  : EncoderClassTestBase<TypeParamModel>
{
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _typeKind;

  public TypeParamEncoderTests()
  {
    _typeKind = RFor<TypeRefModel<TypeKindModel>>();

    Encoder = new TypeParamEncoder(_typeKind);
  }

  protected override IEncoder<TypeParamModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string input, string contents, string typeName)
  {
    TypeRefModel<TypeKindModel> typeRef = new(TypeKindModel.Special, typeName, string.Empty);

    EncodeReturnsMap(_typeKind, "_TypeRef", typeName);

    EncodeAndCheck(new(input, contents, typeRef),
      TagAll("_TypeParam",
        ":constraint:value=[_TypeRef]" + typeName.QuotedIdentifier(),
        ":description=" + contents.QuotedIdentifier(),
        ":name=" + input));
  }
}
