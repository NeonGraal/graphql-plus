using GqlPlus.Generating;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class GeneratorRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact, Trait("Generate", "Html")]
  public void Generators()
    => GeneratorRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(), b => b.AddSchemaGenerators());

  [Fact]
  public void GeneratorRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddGenerators(b => b.AddSchemaGenerators())
      .BuildServiceProvider();

    services.GetService<IGeneratorRepository>()
        .ShouldNotBeNull();
  }
}
