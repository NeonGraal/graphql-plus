namespace GqlPlus.Encoding;

public class OpFragmentEncoderTests
  : EncoderClassTestBase<OpFragmentModel>
{
  private readonly IEncoder<OpDirectiveModel> _directives;
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _type;

  public OpFragmentEncoderTests()
  {
    _directives = RFor<OpDirectiveModel>();
    _type = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_directives);
    encoders.EncoderForReturns(_type);
    Encoder = new OpFragmentEncoder(encoders);
  }

  protected override IEncoder<OpFragmentModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidFragmentModel_ReturnsStructured(string name, string typeName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> typeRef = typeName.TypeRef(TypeKindModel.Output);
    _type.Encode(typeRef).Returns(typeName.Encode("TypeRef"));

    // Act
    EncodeAndCheck(new(name, typeRef, string.Empty), [
        "[_OpFragment]:name=" + name,
        "[_OpFragment]:type=[TypeRef]" + typeName,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithDirectives_IncludesDirectives(string name, string typeName, string dirName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> typeRef = typeName.TypeRef(TypeKindModel.Output);
    _type.Encode(typeRef).Returns(typeName.Encode("TypeRef"));
    OpDirectiveModel dirModel = new(dirName, "");
    _directives.Encode(dirModel).Returns(dirName.Encode("_OpDirective"));

    // Act
    EncodeAndCheck(new(name, typeRef, string.Empty) {
      Directives = [dirModel]
    }, [
        "[_OpFragment]:directives.0=[_OpDirective]" + dirName,
        "[_OpFragment]:name=" + name,
        "[_OpFragment]:type=[TypeRef]" + typeName,
      ]);
  }
}
