namespace GqlPlus.Encoding.Objects;

public class DualArgEncoderTests
  : EncoderClassTestBase<DualArgModel>
{
  protected override IEncoder<DualArgModel> Encoder { get; }
    = new DualArgEncoder();

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string dual, string contents)
    => EncodeAndCheck(new(dual, contents) { IsTypeParam = true }, [
      "!_DualArg",
      "description: " + contents.Quoted("'"),
      "typeParam: " + dual
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithDual(string dual, string contents)
    => EncodeAndCheck(new(dual, contents), [
      "!_DualArg",
      "description: " + contents.Quoted("'"),
      "dual: " + dual
      ]);
}
