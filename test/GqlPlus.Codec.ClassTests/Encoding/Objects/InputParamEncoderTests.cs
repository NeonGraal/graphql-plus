namespace GqlPlus.Encoding.Objects;

public class InputParamEncoderTests
  : EncoderClassTestBase<InputParamModel>
{
  private readonly IEncoder<TypeArgModel> _objArg;
  private readonly IEncoder<ModifierModel> _modifier;
  private readonly IEncoder<ConstantModel> _constant;

  public InputParamEncoderTests()
  {
    _objArg = RFor<TypeArgModel>();
    _modifier = RFor<ModifierModel>();
    _constant = RFor<ConstantModel>();

    Encoder = new InputParamEncoder(_objArg, _modifier, _constant);
  }

  protected override IEncoder<InputParamModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string input, string contents)
    => EncodeAndCheck(new(input, contents),
      TagAll("_InputParam",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + input));
}
