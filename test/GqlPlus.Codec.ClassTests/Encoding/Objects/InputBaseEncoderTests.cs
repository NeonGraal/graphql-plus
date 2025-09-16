namespace GqlPlus.Encoding.Objects;

public class InputBaseEncoderTests
  : ObjectArgEncoderBase<ObjBaseModel>
{
  public InputBaseEncoderTests()
    => Encoder = new InputBaseEncoder(ObjArg);

  protected override IEncoder<ObjBaseModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string input, string contents)
    => EncodeAndCheck(new(input, contents) { IsTypeParam = true }, [
      "!_ObjBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + input
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithInput(string input, string contents)
    => EncodeAndCheck(new(input, contents), [
      "!_ObjBase",
      "description: " + contents.Quoted("'"),
      "name: " + input
      ]);

  [Theory, RepeatData]
  public void Encode_WithArg_ReturnsStructuredWithInput(string input, string argType)
  {
    ObjTypeArgModel argModel = new(TypeKindModel.Input, argType, "");
    ObjBaseModel model = new(input, "") { Args = [argModel] };

    EncodeReturnsMap(ObjArg, "_ObjTypeArg", argType);

    EncodeAndCheck(model, [
      "!_ObjBase",
      "name: " + input,
      "typeArgs:", "  -", $"    value: !_ObjTypeArg '{argType}'"
      ]);
  }


}
