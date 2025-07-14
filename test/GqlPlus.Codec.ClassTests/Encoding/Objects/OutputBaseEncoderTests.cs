namespace GqlPlus.Encoding.Objects;

public class OutputBaseEncoderTests
  : ObjectArgEncoderBase<OutputBaseModel, OutputArgModel>
{
  private readonly IEncoder<DualBaseModel> _dual;

  public OutputBaseEncoderTests()
  {
    _dual = RFor<DualBaseModel>();

    Encoder = new OutputBaseEncoder(ObjArg, _dual);
  }

  protected override IEncoder<OutputBaseModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => EncodeAndCheck(new(output, contents) { IsTypeParam = true }, [
      "!_OutputBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + output
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => EncodeAndCheck(new(output, contents), [
      "!_OutputBase",
      "description: " + contents.Quoted("'"),
      "name: " + output
      ]);
}
