namespace GqlPlus.Encoding.Objects;

public class OutputArgEncoderTests
  : EncoderClassTestBase<OutputArgModel>
{
  private readonly IEncoder<DualArgModel> _dual;
  private readonly IEncoder<TypeRefModel<SimpleKindModel>> _label;

  public OutputArgEncoderTests()
  {
    _dual = RFor<DualArgModel>();
    _label = RFor<TypeRefModel<SimpleKindModel>>();

    Encoder = new OutputArgEncoder(_dual, _label);
  }

  protected override IEncoder<OutputArgModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => EncodeAndCheck(new(output, contents) { IsTypeParam = true }, [
      "!_OutputArg",
      "description: " + contents.Quoted("'"),
      "typeParam: " + output
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => EncodeAndCheck(new(output, contents), [
      "!_OutputArg",
      "description: " + contents.Quoted("'"),
      "output: " + output
      ]);
}
