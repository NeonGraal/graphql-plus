namespace GqlPlus.Encoding.Objects;

public class OutputFieldEncoderTests
  : ObjectBaseEncoderBase<OutputFieldModel, ObjBaseModel>
{
  private readonly IEncoder<ModifierModel> _modifer;
  private readonly IEncoder<OutputEnumModel> _outputEnum;
  private readonly IEncoder<InputParamModel> _parameter;

  public OutputFieldEncoderTests()
  {
    _outputEnum = RFor<OutputEnumModel>();
    _modifer = RFor<ModifierModel>();
    _parameter = RFor<InputParamModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderFor<OutputEnumModel>().Returns(_outputEnum);
    encoders.EncoderFor<ModifierModel>().Returns(_modifer);
    encoders.EncoderFor<ObjBaseModel>().Returns(ObjBase);
    encoders.EncoderFor<InputParamModel>().Returns(_parameter);
    Encoder = new OutputFieldEncoder(encoders);
  }

  protected override IEncoder<OutputFieldModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string output, string contents)
  {
    // Arrange
    ObjBaseModel outputBase = new(output, "");
    ObjBase.Encode(outputBase).Returns(output.Encode());

    // Act & Accept
    EncodeAndCheck(new(name, outputBase, contents),
      TagAll("_OutputField",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + name,
      ":type=" + output));
  }
}
