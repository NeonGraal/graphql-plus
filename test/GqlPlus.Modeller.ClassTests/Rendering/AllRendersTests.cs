using GqlPlus.Structures;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Rendering;

public class AllRendersTests
{
  [Fact]
  public void AllRenderers_DefinesRender_Simple()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddRenderers()
      .BuildServiceProvider();

    services.GetService<IRenderer<SimpleModel>>()
      .ShouldNotBeNull();
  }
}
