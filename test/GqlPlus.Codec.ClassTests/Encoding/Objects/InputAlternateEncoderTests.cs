namespace GqlPlus.Encoding.Objects;

public class InputAlternateEncoderTests
  : ObjectBaseEncoderBase<ObjAlternateModel, ObjBaseModel>
{
  private readonly IEncoder<CollectionModel> _collection;
  private readonly IEncoder<ObjBaseModel> _objBaseEncoder;

  public InputAlternateEncoderTests()
  {
    _collection = RFor<CollectionModel>();
    _objBaseEncoder = A.Of<IEncoder<ObjBaseModel>>();
    Encoder = new ObjectAlternateEncoder(new(_collection, _objBaseEncoder));
  }

  protected override IEncoder<ObjAlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_ReturnsStructuredWithOutput(string input)
  {
    ObjBaseModel objBase = new(input, "");
    _objBaseEncoder.Encode(objBase).Returns(new Structured(input));
    EncodeAndCheck(new(objBase), [
        "!_ObjAlternate",
        "type: " + input
      ]);
  }
}
