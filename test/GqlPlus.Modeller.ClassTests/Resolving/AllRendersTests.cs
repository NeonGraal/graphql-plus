using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Resolving;

public class AllResolversTests
{
  [Fact]
  public void AllResolvers_DefinesResolver_Enum()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddResolvers()
      .BuildServiceProvider();

    services.GetService<IResolver<TypeEnumModel>>()
      .ShouldNotBeNull();
  }
}
