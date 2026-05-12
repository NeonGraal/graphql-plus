using GqlPlus.Decoding;
using GqlPlus.Encoding;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class CodecRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact, Trait("Generate", "Html")]
  public void Decoders()
    => DecoderRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaDecoders());

  [Fact, Trait("Generate", "Html")]
  public void Encoders()
    => EncoderRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaEncoders());

  [Fact]
  public void DecoderRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddDecoders()
      .BuildServiceProvider();

    services.GetService<IDecoderRepository>()
        .ShouldNotBeNull();
  }

  [Fact]
  public void EncoderRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddEncoders()
      .BuildServiceProvider();

    services.GetService<IEncoderRepository>()
        .ShouldNotBeNull();
  }
}
