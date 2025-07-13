namespace GqlPlus.Encoding.Objects;

public class InputArgEncoderTests
  : EncoderClassTestBase<InputArgModel>
{
  private readonly IEncoder<DualArgModel> _dual;

  public InputArgEncoderTests()
  {
    _dual = RFor<DualArgModel>();

    Encoder = new InputArgEncoder(_dual);
  }

  protected override IEncoder<InputArgModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string input, string contents)
    => EncodeAndCheck(new(TypeKindModel.Input, input, contents) { IsTypeParam = true }, [
      "!_InputArg",
      "description: " + contents.Quoted("'"),
      "typeParam: " + input
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithInput(string input, string contents)
    => EncodeAndCheck(new(TypeKindModel.Input, input, contents), [
      "!_InputArg",
      "description: " + contents.Quoted("'"),
      "name: " + input
      ]);

  [Theory, RepeatData]
  public void Encode_WithDual_ReturnsStructuredWithInput(string input)
  {
    InputArgModel model = new(TypeKindModel.Input, "", "") { Dual = new(TypeKindModel.Dual, input, "") };

    EncodeReturnsMap(_dual, "_DualArg", input);

    EncodeAndCheck(model, [$"value: !_DualArg '{input}'"]);
  }
}
