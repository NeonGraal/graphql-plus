using GqlPlus.Decoding;
using GqlPlus.Encoding;

namespace GqlPlus;

public class CodecRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void Decoders()
    => DecoderRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaDecoders());

  [Fact]
  public void Encoders()
    => EncoderRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaEncoders());
}
