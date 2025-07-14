namespace GqlPlus.Encoding.Objects;

public class DualAlternateEncoderTests
  : ObjectBaseEncoderBase<DualAlternateModel, DualBaseModel>
{
  private readonly IEncoder<CollectionModel> _collection;

  public DualAlternateEncoderTests()
  {
    _collection = RFor<CollectionModel>();

    Encoder = new ObjectAlternateEncoder<DualAlternateModel, DualBaseModel>(new(_collection, ObjBase));
  }

  protected override IEncoder<DualAlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithDual(string dual)
  {
    DualBaseModel objBase = new(dual, "");
    ObjBase.Encode(objBase).Returns(new Structured(dual));
    EncodeAndCheck(new(objBase), [
        "!_DualAlternate",
        "type: " + dual
      ]);
  }
}
