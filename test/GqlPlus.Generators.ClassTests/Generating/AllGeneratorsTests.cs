using GqlPlus.Ast.Schema;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Generating;

public class AllGeneratorsTests
{
  [Fact]
  public void AllGenerators_Repository_IsRegistered()
    => _services.GetService<IGeneratorRepository>()
      .ShouldNotBeNull();

  [Fact]
  public void AllGenerators_GeneratorForSchema_IsRegistered()
    => _services.GetRequiredService<IGeneratorRepository>()
      .GeneratorFor<IAstSchema>()
      .ShouldNotBeNull();

  [Fact]
  public void AllGenerators_TypeGenerators_ReturnNotEmpty()
    => _services.GetRequiredService<IGeneratorRepository>()
    .TypeGenerators.ShouldNotBeEmpty();

  [Fact]
  public void AllGenerators_GeneratorFactories_ReturnNotNull()
  {
    IGeneratorRepository repo = _services.GetRequiredService<IGeneratorRepository>();
    GeneratorRepositoryBuilder builder = _services.GetRequiredService<GeneratorRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Generators.Values.Select(CheckGenerator)]);
  }

  [Fact]
  public void AllGenerators_TypeGeneratorFactories_ReturnNotNull()
  {
    IGeneratorRepository repo = _services.GetRequiredService<IGeneratorRepository>();
    GeneratorRepositoryBuilder builder = _services.GetRequiredService<GeneratorRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.TypeGenerators.Values
      .SelectMany(fs => fs)
      .Select(CheckGenerator)]);
  }

  private static Action<IGeneratorRepository> CheckGenerator(Factory<object, IGeneratorRepository> factory)
    => r => factory(r)
        .ShouldNotBeNull($"Generator for {factory.GetType().ExpandTypeName()} should not be null");

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddGenerators()
    .BuildServiceProvider();
}
