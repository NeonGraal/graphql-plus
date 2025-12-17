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
    Encoder = new ObjectAlternateEncoder(new(_collection, _objBaseEncoder));
  }

  protected override IEncoder<AlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithDual(string dual)
  {
    ObjBaseModel objBase = new(dual, "");
    _objBaseEncoder.Encode(objBase).Returns(new Structured(dual));
    EncodeAndCheck(new(objBase),
        TagAll("_Alternate",
        ":type=" + dual));
  }
}
