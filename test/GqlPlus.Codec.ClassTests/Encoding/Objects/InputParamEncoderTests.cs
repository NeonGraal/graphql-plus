namespace GqlPlus.Encoding.Objects;

public class InputParamEncoderTests
  : EncoderClassTestBase<InputParamModel>
{
  private readonly IEncoder<ObjTypeArgModel> _objArg;
  private readonly IEncoder<DualBaseModel> _dual;
  private readonly IEncoder<ModifierModel> _modifier;
  private readonly IEncoder<ConstantModel> _constant;

  public InputParamEncoderTests()
  {
    _objArg = RFor<ObjTypeArgModel>();
    _dual = RFor<DualBaseModel>();
    _modifier = RFor<ModifierModel>();
    _constant = RFor<ConstantModel>();

    Encoder = new InputParamEncoder(_objArg, _dual, _modifier, _constant);
  }

  protected override IEncoder<InputParamModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string input, string contents)
    => EncodeAndCheck(new(input, contents), [
      "!_InputParam",
      "description: " + contents.Quoted("'"),
      "name: " + input
      ]);
}
