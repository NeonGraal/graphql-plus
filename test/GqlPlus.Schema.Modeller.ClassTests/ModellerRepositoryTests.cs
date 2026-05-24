using GqlPlus.Modelling;
using GqlPlus.Resolving;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class ModellerRepositoryTests(
  ITestOutputHelper outputHelper
) : SubstituteBase
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
      .AddModellers(b => b.AddSchemaModellers())
      .BuildServiceProvider();

    services.GetService<IModellerRepository>()
        .ShouldNotBeNull();
  }

  [Fact]
  public void ModelSchema()
  {
    // Arrange
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddModellers(b => b.AddSchemaModellers())
      .BuildServiceProvider();

    Modeller<IAstSchema, SchemaModel> factory = services
      .GetService<IModellerRepository>()
      .ShouldNotBeNull()
      .ModellerFor<IAstSchema, SchemaModel>();

    IAstSchema schema = A.Of<IAstSchema>();
    Map<TypeKindModel> typeKinds = [];

    // Act
    SchemaModel result = factory.ToModel(schema, typeKinds);

    //Assert
    result.ShouldNotBeNull();
  }

  [Fact]
  public void ResolverRepository()
  {
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddResolvers(b => b.AddSchemaResolvers())
      .BuildServiceProvider();

    services.GetService<IResolverRepository>()
        .ShouldNotBeNull();
  }

  [Fact]
  public void ResolveSchema()
  {
    // Arrange
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddResolvers(b => b.AddSchemaResolvers())
      .BuildServiceProvider();

    Resolver<SchemaModel> factory = services
      .GetService<IResolverRepository>()
      .ShouldNotBeNull()
      .ResolverFor<SchemaModel>();

    IResolveContext context = A.Of<IResolveContext>();
    SchemaModel schema = new("Test", "");

    // Act
    SchemaModel result = factory.Resolve(schema, context).ShouldNotBeNull();

    // Assert
    result.ShouldNotBeNull();
  }
}
