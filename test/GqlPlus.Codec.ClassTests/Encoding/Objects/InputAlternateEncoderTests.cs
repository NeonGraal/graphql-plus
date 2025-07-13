namespace GqlPlus.Encoding.Objects;

public class InputAlternateEncoderTests
  : ObjectBaseEncoderBase<InputAlternateModel, InputBaseModel>
{
  private readonly IEncoder<CollectionModel> _collection;

  public InputAlternateEncoderTests()
  {
    _collection = RFor<CollectionModel>();

    Encoder = new ObjectAlternateEncoder<InputAlternateModel, InputBaseModel>(new(_collection, ObjBase));
  }

  protected override IEncoder<InputAlternateModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_ReturnsStructuredWithOutput(string input)
  {
    InputBaseModel objBase = new(input, "");
    ObjBase.Encode(objBase).Returns(new Structured(input));
    EncodeAndCheck(new(objBase), [
        "!_InputAlternate",
        "type: " + input
      ]);
  }
}
