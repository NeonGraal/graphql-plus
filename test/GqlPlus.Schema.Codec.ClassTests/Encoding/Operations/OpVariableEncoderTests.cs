namespace GqlPlus.Encoding;

public class OpVariableEncoderTests
  : EncoderClassTestBase<OpVariableModel>
{
  private readonly IEncoder<OpDirectiveModel> _directives;
  private readonly IEncoder<ConstantModel> _constant;
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _type;

  public OpVariableEncoderTests()
  {
    _directives = RFor<OpDirectiveModel>();
    _constant = RFor<ConstantModel>();
    _type = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_directives);
    encoders.EncoderForReturns(_constant);
    encoders.EncoderForReturns(_type);
    Encoder = new OpVariableEncoder(encoders);
  }

  protected override IEncoder<OpVariableModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidVariableModel_ReturnsStructured(string name, string typeName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> typeRef = typeName.TypeRef(TypeKindModel.Input);
    _type.Encode(typeRef).Returns(typeName.Encode("TypeRef"));

    // Act
    EncodeAndCheck(new(name, typeRef, null, string.Empty), [
        "[_OpVariable]:name=" + name,
        "[_OpVariable]:type=[TypeRef]" + typeName,
      ]);
  }
}
