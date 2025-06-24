namespace GqlPlus.Encoding.Objects;

public class OutputAlternateEncoderTests
  : ObjectBaseEncoderBase<OutputAlternateModel, OutputBaseModel>
{
  private readonly IEncoder<CollectionModel> _collection;

  public OutputAlternateEncoderTests()
  {
    _collection = RFor<CollectionModel>();

    Encoder = new ObjectAlternateEncoder<OutputAlternateModel, OutputBaseModel>(new(_collection, ObjBase));
  }

  protected override IEncoder<OutputAlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_ReturnsStructuredWithOutput(string output)
  {
    OutputBaseModel objBase = new(output, "");
    ObjBase.Encode(objBase).Returns(new Structured(output));
    EncodeAndCheck(new(objBase), [
        "!_OutputAlternate",
        "type: " + output
      ]);
  }
}
