namespace GqlPlus.Encoding.Objects;

public class OutputAlternateEncoderTests
  : ObjectBaseEncoderBase<ObjAlternateModel, ObjBaseModel>
{
  private readonly IEncoder<CollectionModel> _collection;
  private readonly IEncoder<ObjBaseModel> _objBaseEncoder;

  public OutputAlternateEncoderTests()
  {
    _collection = RFor<CollectionModel>();
    _objBaseEncoder = A.Of<IEncoder<ObjBaseModel>>();
    Encoder = new ObjectAlternateEncoder(new(_collection, _objBaseEncoder));
  }

  protected override IEncoder<ObjAlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_ReturnsStructuredWithOutput(string output)
  {
    ObjBaseModel objBase = new(output, "");
    _objBaseEncoder.Encode(objBase).Returns(new Structured(output));
    EncodeAndCheck(new(objBase), [
        "!_ObjAlternate",
        "type: " + output
      ]);
  }
}
