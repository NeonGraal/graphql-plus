using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Encoding;

public class AllEncodersTests
{
  [Fact]
  public void AllEncoders_DefinesEncode_Simple()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddEncoders()
      .BuildServiceProvider();

    services.GetService<IEncoder<SimpleModel>>()
      .ShouldNotBeNull();
  }
}
