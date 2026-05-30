namespace GqlPlus.Encoding;

public class OpResultEncoderTests
  : EncoderClassTestBase<OpResultModel>
{
  private readonly IEncoder<TypeRefModel<TypeKindModel>> _domain;

  public OpResultEncoderTests()
  {
    _domain = RFor<TypeRefModel<TypeKindModel>>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
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
}
