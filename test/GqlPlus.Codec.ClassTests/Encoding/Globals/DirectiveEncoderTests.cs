namespace GqlPlus.Encoding.Globals;

public class DirectiveEncoderTests
  : EncoderClassTestBase<DirectiveModel>
{
  public DirectiveEncoderTests()
  {
    _parameter = RFor<InputParamModel>();
    Encoder = new DirectiveEncoder(_parameter);
  }

  private readonly IEncoder<InputParamModel> _parameter;

  protected override IEncoder<DirectiveModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidDirectiveModel_ReturnsStructured(string name, string contents, string input)
  {
    // Arrange
    InputParamModel parameter = new(input, "");
    _parameter.Encode(parameter).Returns(new Structured(input));

    // Act
    EncodeAndCheck(new(name, contents) {
      Locations = DirectiveLocation.Operation,
      Parameters = [parameter],
      Repeatable = true,
    }, [
        $"[_Directive]:description=" + contents.QuotedIdentifier(),
        "[_Directive]:locations[_Set(_Location)]:Operation=_",
        "[_Directive]:name=" + name,
        "[_Directive]:parameters.0=" + input,
        "[_Directive]:repeatable=true"
        ]);
  }
}
