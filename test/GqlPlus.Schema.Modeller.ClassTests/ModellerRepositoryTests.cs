using GqlPlus.Modelling;
using GqlPlus.Resolving;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class ModellerRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact, Trait("Generate", "Html")]
  public void Modellers()
    => ModellerRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaModellers());

  [Fact, Trait("Generate", "Html")]
  public void Resolvers()
    => ResolverRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaResolvers());

  [Fact]
  public void ModellerRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddModellers()
      .BuildServiceProvider();

    services.GetService<IModellerRepository>()
        .ShouldNotBeNull();
  }

  [Fact]
  public void ResolverRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddResolvers()
      .BuildServiceProvider();

    services.GetService<IResolverRepository>()
        .ShouldNotBeNull();
  }
}
