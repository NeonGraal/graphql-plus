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

  [Theory, ClassData<DefinedGeneratorTypes>]
  public void AllGenerators_TypeGenerators_ReturnNotEmpty(GqlpGeneratorType generatorType)
    => _services.GetRequiredService<IGeneratorRepository>()
    .TypeGenerators(generatorType).ShouldNotBeEmpty();

  [Fact]
  public void AllGenerators_GeneratorFactories_ReturnNotNull()
  {
    IGeneratorRepository repo = _services.GetRequiredService<IGeneratorRepository>();
    GeneratorRepositoryBuilder builder = _services.GetRequiredService<GeneratorRepositoryBuilder>();

    repo.ShouldSatisfyAllConditions([.. builder.Generators.Values.Select(CheckGenerator)]);
  }

  [Theory, ClassData<DefinedGeneratorTypes>]
  public void AllGenerators_TypeGeneratorFactories_ReturnNotNull(GqlpGeneratorType generatorType)
  {
    IGeneratorRepository repo = _services.GetRequiredService<IGeneratorRepository>();

    repo.ShouldSatisfyAllConditions([.. repo.TypeGenerators(generatorType)
      .Select(CheckTypeGenerator)]);
  }

  private static Action<IGeneratorRepository> CheckGenerator(Factory<object, IGeneratorRepository> factory)
    => r => factory(r)
        .ShouldNotBeNull($"Generator for {factory.GetType().ExpandTypeName()} should not be null");
  private static Action<IGeneratorRepository> CheckTypeGenerator(ITypeGenerator generator)
    => r => generator
        .ShouldNotBeNull($"Type generator for {generator.GetType().ExpandTypeName()} should not be null");

  private readonly IServiceProvider _services = new ServiceCollection()
    .AddLogging()
    .AddGenerators()
    .BuildServiceProvider();
}

public class DefinedGeneratorTypes
  : TheoryData<GqlpGeneratorType>
{
  public DefinedGeneratorTypes()
    : base(
      GqlpGeneratorType.Interface,
      GqlpGeneratorType.Model,
      GqlpGeneratorType.Encoder,
      GqlpGeneratorType.Decoder)
  { }
}
