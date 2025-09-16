namespace GqlPlus.Encoding.Objects;

public class DualBaseEncoderTests
  : ObjectArgEncoderBase<ObjBaseModel>
{
  public DualBaseEncoderTests()
    => Encoder = new DualBaseEncoder(ObjArg);

  protected override IEncoder<ObjBaseModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string dual, string contents)
    => EncodeAndCheck(new(dual, contents) { IsTypeParam = true }, [
      "!_ObjBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + dual
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithDual(string dual, string contents)
    => EncodeAndCheck(new(dual, contents), [
      "!_ObjBase",
      "description: " + contents.Quoted("'"),
      "name: " + dual
      ]);
}
