namespace GqlPlus.Encoding.Objects;

public class DualBaseEncoderTests
  : ObjectArgEncoderBase<DualBaseModel, DualArgModel>
{
  public DualBaseEncoderTests()
    => Encoder = new DualBaseEncoder(ObjArg);

  protected override IEncoder<DualBaseModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string dual, string contents)
    => EncodeAndCheck(new(dual, contents) { IsTypeParam = true }, [
      "!_DualBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + dual
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithDual(string dual, string contents)
    => EncodeAndCheck(new(dual, contents), [
      "!_DualBase",
      "description: " + contents.Quoted("'"),
      "dual: " + dual
      ]);
}
