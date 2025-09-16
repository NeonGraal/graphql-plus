namespace GqlPlus.Encoding.Objects;

public class OutputBaseEncoderTests
  : ObjectArgEncoderBase<ObjBaseModel>
{
  public OutputBaseEncoderTests()
    => Encoder = new OutputBaseEncoder(ObjArg);

  protected override IEncoder<ObjBaseModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructuredWithTypeParam(string output, string contents)
    => EncodeAndCheck(new(output, contents) { IsTypeParam = true }, [
      "!_ObjBase",
      "description: " + contents.Quoted("'"),
      "typeParam: " + output
      ]);

  [Theory, RepeatData]
  public void Encode_WithoutTypeParam_ReturnsStructuredWithOutput(string output, string contents)
    => EncodeAndCheck(new(output, contents), [
      "!_ObjBase",
      "description: " + contents.Quoted("'"),
      "name: " + output
      ]);
}
