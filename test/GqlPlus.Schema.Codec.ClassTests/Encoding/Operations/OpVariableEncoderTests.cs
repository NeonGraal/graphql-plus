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

  [Theory, RepeatData]
  public void Encode_WithDefaultValue_IncludesDefaultValue(string name, string typeName, string defaultValue)
  {
    // Arrange
    TypeRefModel<TypeKindModel> typeRef = typeName.TypeRef(TypeKindModel.Input);
    _type.Encode(typeRef).Returns(typeName.Encode("TypeRef"));
    ConstantModel constantModel = new(new SimpleModel(defaultValue));
    _constant.Encode(constantModel).Returns(defaultValue.Encode("_Constant"));

    // Act
    EncodeAndCheck(new(name, typeRef, constantModel, string.Empty), [
        "[_OpVariable]:defaultValue=[_Constant]" + defaultValue,
        "[_OpVariable]:name=" + name,
        "[_OpVariable]:type=[TypeRef]" + typeName,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithDirectives_IncludesDirectives(string name, string typeName, string dirName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> typeRef = typeName.TypeRef(TypeKindModel.Input);
    _type.Encode(typeRef).Returns(typeName.Encode("TypeRef"));
    OpDirectiveModel dirModel = new(dirName, "");
    _directives.Encode(dirModel).Returns(dirName.Encode("_OpDirective"));

    // Act
    EncodeAndCheck(new(name, typeRef, null, string.Empty) {
      Directives = [dirModel]
    }, [
        "[_OpVariable]:directives.0=[_OpDirective]" + dirName,
        "[_OpVariable]:name=" + name,
        "[_OpVariable]:type=[TypeRef]" + typeName,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithNullType_ExcludesType(string name)
  {
    // Act
    EncodeAndCheck(new(name, null, null, string.Empty), [
        "[_OpVariable]:name=" + name,
      ]);
  }
}
