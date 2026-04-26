namespace GqlPlus.Encoding.Globals;

public class DirectiveEncoderTests
  : EncoderClassTestBase<DirectiveModel>
{
  public DirectiveEncoderTests()
  {
    _parameter = RFor<InputParamModel>();
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderFor<InputParamModel>().Returns(_parameter);
    Encoder = new DirectiveEncoder(encoders);
  }

  private readonly IEncoder<InputParamModel> _parameter;

  protected override IEncoder<DirectiveModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidDirectiveModel_ReturnsStructured(string name, string contents, string input)
  {
    // Arrange
    InputParamModel parameter = new(input, "");
    _parameter.Encode(parameter).Returns(input.Encode());

    // Act
    EncodeAndCheck(new(name, contents) {
      Locations = DirectiveLocationModel.Operation,
      Parameter = parameter,
      Repeatable = true,
    }, [
        $"[_Directive]:description=" + contents.QuotedIdentifier(),
        "[_Directive]:locations[_Set(_Location)]:Operation=_",
        "[_Directive]:name=" + name,
        "[_Directive]:parameter=" + input,
        "[_Directive]:repeatable=true"
        ]);
  }
}
