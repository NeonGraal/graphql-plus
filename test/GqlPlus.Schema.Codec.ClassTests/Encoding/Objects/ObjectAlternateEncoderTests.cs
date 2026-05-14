namespace GqlPlus.Encoding.Objects;

public class ObjectAlternateEncoderTests
  : ObjectBaseEncoderBase<AlternateModel, ObjBaseModel>
{
  private readonly IEncoder<CollectionModel> _collection;
  private readonly IEncoder<ObjBaseModel> _objBaseEncoder;

  public ObjectAlternateEncoderTests()
  {
    _collection = RFor<CollectionModel>();
    _objBaseEncoder = A.Of<IEncoder<ObjBaseModel>>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(_collection);
    encoders.EncoderForReturns(_objBaseEncoder);
    Encoder = new ObjectAlternateEncoder(encoders);
  }

  protected override IEncoder<AlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithDual(string dual)
  {
    ObjBaseModel objBase = new(dual, "");
    _objBaseEncoder.Encode(objBase).Returns(dual.Encode());
    EncodeAndCheck(new(objBase),
        TagAll("_Alternate",
        ":type=" + dual));
  }
}
