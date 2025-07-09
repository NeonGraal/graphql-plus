using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Decoding;

public class AllDecodersTests
{
  [Fact]
  public void AllDecoders_DefinesDecode_CategoryFilterModel()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddDecoders()
      .BuildServiceProvider();

    services.GetService<IDecoder<CategoryFilterModel>>()
      .ShouldNotBeNull();
  }
}
