using GqlPlus.Generating;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class GeneratorRepositoryTests(
  ITestOutputHelper outputHelper
) : SubstituteBase
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

  [Fact]
  public void GenerateSchema()
  {
    // Arrange
    IServiceProvider services = new ServiceCollection()
      .AddLogging()
      .AddGenerators(b => b.AddSchemaGenerators())
      .BuildServiceProvider();

    Generator<IAstSchema> factory = services
      .GetService<IGeneratorRepository>()
      .ShouldNotBeNull()
      .GeneratorFor<IAstSchema>();

    IAstSchema ast = A.Of<IAstSchema>();
    GqlpGeneratorOptions generatorOptions = new("Test", GqlpBaseType.Interface, GqlpGeneratorType.Interface);
    GqlpModelOptions modelOptions = new("Test.Test", "Test");
    GqlpGeneratorContext context = new(".", generatorOptions, modelOptions);

    // Act
    factory.Generate(ast, context);
  }
}
