namespace GqlPlus.Encoding;

public class OpDirectiveEncoderTests
  : EncoderClassTestBase<OpDirectiveModel>
{
  public OpDirectiveEncoderTests()
    => Encoder = new OpDirectiveEncoder();

  protected override IEncoder<OpDirectiveModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidDirectiveModel_ReturnsStructured(string name)
  {
    // Act
    EncodeAndCheck(new(name, string.Empty), [
        "[_OpDirective]:name=" + name,
      ]);
  }
}
