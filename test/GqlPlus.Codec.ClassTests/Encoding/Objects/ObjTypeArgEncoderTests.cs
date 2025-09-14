namespace GqlPlus.Encoding.Objects;

public class ObjTypeArgEncoderTests
  : EncoderClassTestBase<ObjTypeArgModel>
{
  private readonly IEncoder<TypeRefModel<SimpleKindModel>> _label;

  public ObjTypeArgEncoderTests()
  {
    _label = RFor<TypeRefModel<SimpleKindModel>>();

    Encoder = new ObjTypeArgEncoder(_label);
  }

  protected override IEncoder<ObjTypeArgModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => EncodeAndCheck(new(TypeKindModel.Output, output, contents) { IsTypeParam = true }, [
      "!_ObjTypeArg",
      "description: " + contents.Quoted("'"),
      "typeParam: " + output
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => EncodeAndCheck(new(TypeKindModel.Output, output, contents), [
      "!_ObjTypeArg",
      "description: " + contents.Quoted("'"),
      "name: " + output
      ]);
}
