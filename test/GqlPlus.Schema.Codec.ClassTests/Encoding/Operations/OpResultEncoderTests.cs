namespace GqlPlus.Encoding;

public class OpResultEncoderTests
  : EncoderClassTestBase<OpResultModel>
{
  private readonly IEncoder<OpArgumentModel> _argument;
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _domain;

  public OpResultEncoderTests()
  {
    _argument = RFor<OpArgumentModel>();
    _domain = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_argument);
    encoders.EncoderForReturns(_domain);
    Encoder = new OpResultEncoder(encoders);
  }

  protected override IEncoder<OpResultModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidResultModel_ReturnsStructured(string typeName)
  {
    // Arrange
    TypeRefModel<TypeKindModel> domainRef = typeName.TypeRef(TypeKindModel.Output);
    _domain.Encode(domainRef).Returns(typeName.Encode("TypeRef"));

    // Act
    EncodeAndCheck(new(domainRef), [
        "[_OpResult]:domain=[TypeRef]" + typeName,
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithArgument_IncludesArgument(string typeName, string argValue)
  {
    // Arrange
    TypeRefModel<TypeKindModel> domainRef = typeName.TypeRef(TypeKindModel.Output);
    _domain.Encode(domainRef).Returns(typeName.Encode("TypeRef"));
    OpArgumentModel argModel = new();
    _argument.Encode(argModel).Returns(argValue.Encode("_OpArgument"));

    // Act
    EncodeAndCheck(new(domainRef) { Argument = argModel }, [
        "[_OpResult]:argument=[_OpArgument]" + argValue,
        "[_OpResult]:domain=[TypeRef]" + typeName,
      ]);
  }
}
