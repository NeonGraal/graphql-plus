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
    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderFor<TypeArgModel>().Returns(_objArg);
    encoders.EncoderFor<ModifierModel>().Returns(_modifier);
    encoders.EncoderFor<ConstantModel>().Returns(_constant);
    Encoder = new InputParamEncoder(encoders);
  }

  protected override IEncoder<InputParamModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string input, string contents)
    => EncodeAndCheck(new(input, contents),
      TagAll("_InputParam",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + input));
}
