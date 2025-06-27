namespace GqlPlus.Encoding.Objects;

public class OutputFieldEncoderTests
  : ObjectBaseEncoderBase<OutputFieldModel, OutputBaseModel>
{
  private readonly IEncoder<ModifierModel> _modifer;
  private readonly IEncoder<OutputEnumModel> _outputEnum;
  private readonly IEncoder<InputParamModel> _parameter;

  public OutputFieldEncoderTests()
  {
    _outputEnum = RFor<OutputEnumModel>();
    _modifer = RFor<ModifierModel>();
    _parameter = RFor<InputParamModel>();

    Encoder = new OutputFieldEncoder(_outputEnum, new(_modifer, ObjBase), _parameter);
  }

  protected override IEncoder<OutputFieldModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string output, string contents)
  {
    // Arrange
    OutputBaseModel outputBase = new(output, "");
    ObjBase.Encode(outputBase).Returns(new Structured(output));

    // Act & Accept
    EncodeAndCheck(new(name, outputBase, contents), [
      "!_OutputField",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "type: " + output
      ]);
  }
}
