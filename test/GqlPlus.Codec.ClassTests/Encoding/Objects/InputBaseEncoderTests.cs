namespace GqlPlus.Encoding.Objects;

public class InputBaseEncoderTests
  : ObjectArgEncoderBase<InputBaseModel>
{
  public InputBaseEncoderTests()
    => Encoder = new InputBaseEncoder(ObjArg);

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
    ObjTypeArgModel argModel = new(TypeKindModel.Input, argType, "");
    InputBaseModel model = new(input, "") { Args = [argModel] };

    EncodeReturnsMap(ObjArg, "_ObjTypeArg", argType);

    EncodeAndCheck(model, [
      "!_InputBase",
      "name: " + input,
      "typeArgs:", "  -", $"    value: !_ObjTypeArg '{argType}'"
      ]);
  }


}
