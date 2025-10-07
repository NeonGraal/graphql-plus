namespace GqlPlus.Encoding.Objects;

public class ObjTypeArgEncoderTests
  : EncoderClassTestBase<ObjTypeArgModel>
{
  private readonly IEncoder<EnumValueModel> _enumValue;

  public ObjTypeArgEncoderTests()
  {
    _enumValue = RFor<EnumValueModel>();

    Encoder = new ObjTypeArgEncoder(_enumValue);
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
