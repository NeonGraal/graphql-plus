namespace GqlPlus.Encoding.Objects;

public class OutputAlternateEncoderTests
  : ObjectBaseEncoderBase<OutputAlternateModel, OutputBaseModel>
{
  private readonly IEncoder<CollectionModel> _collection;
  private readonly IEncoder<ObjBaseModel> _objBaseEncoder;

  public OutputAlternateEncoderTests()
  {
    _collection = RFor<CollectionModel>();
    _objBaseEncoder = A.Of<IEncoder<ObjBaseModel>>();
    Encoder = new ObjectAlternateEncoder<OutputAlternateModel>(new(_collection, _objBaseEncoder));
  }

  protected override IEncoder<OutputAlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_ReturnsStructuredWithOutput(string output)
  {
    OutputBaseModel objBase = new(output, "");
    _objBaseEncoder.Encode(objBase).Returns(new Structured(output));
    EncodeAndCheck(new(objBase), [
        "!_OutputAlternate",
        "type: " + output
      ]);
  }
}
