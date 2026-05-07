using GqlPlus.Modelling;
using GqlPlus.Resolving;

namespace GqlPlus;

public class ModellerRepositoryTests(ITestOutputHelper outputHelper)
{
  [Fact]
  public void Modellerss()
    => ModellerRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaModellers());

  [Fact]
  public void Resolvers()
    => ResolverRepoWrapper.WriteTree(outputHelper.ToLoggerFactory(),
      v => v.AddSchemaResolvers());
}
