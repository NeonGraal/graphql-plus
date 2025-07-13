namespace GqlPlus.Encoding.Objects;

public class InputBaseEncoderTests
  : ObjectArgEncoderBase<InputBaseModel, InputArgModel>
{
  private readonly IEncoder<DualBaseModel> _dual;

  public InputBaseEncoderTests()
  {
    _dual = RFor<DualBaseModel>();

    Encoder = new InputBaseEncoder(ObjArg, _dual);
  }

  protected override IEncoder<InputBaseModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string input, string contents)
    => EncodeAndCheck(new(input, contents) { IsTypeParam = true }, [
      "!_InputBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + input
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithInput(string input, string contents)
    => EncodeAndCheck(new(input, contents), [
      "!_InputBase",
      "description: " + contents.Quoted("'"),
      "name: " + input
      ]);

  [Theory, RepeatData]
  public void Encode_WithArg_ReturnsStructuredWithInput(string input, string argType)
  {
    InputArgModel argModel = new(TypeKindModel.Input, argType, "");
    InputBaseModel model = new(input, "") { Args = [argModel] };

    EncodeReturnsMap(ObjArg, "_InputArg", argType);

    EncodeAndCheck(model, [
      "!_InputBase",
      "name: " + input,
      "typeArgs:", "  -", $"    value: !_InputArg '{argType}'"
      ]);
  }

  [Theory, RepeatData]
  public void Encode_WithDual_ReturnsStructuredWithInput(string input)
  {
    InputBaseModel model = new("", "") { Dual = new DualBaseModel(input, "") };

    EncodeReturnsMap(_dual, "_DualBase", input);

    EncodeAndCheck(model, [$"value: !_DualBase '{input}'"]);
  }
}
