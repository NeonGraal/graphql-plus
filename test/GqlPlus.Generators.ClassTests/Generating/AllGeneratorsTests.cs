using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Generating;

public class AllGeneratorsTests
{
  [Fact]
  public void AllGenerators_DefinesGenerator_FieldKey()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddGenerators()
      .BuildServiceProvider();

    services.GetService<IGenerator<IGqlpSchema>>()
      .ShouldNotBeNull();
  }
}
