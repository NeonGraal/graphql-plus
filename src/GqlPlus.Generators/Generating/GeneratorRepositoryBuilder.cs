using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal class GeneratorRepositoryBuilder
  : BaseFactory<IGeneratorRepository>, IGeneratorRepositoryBuilder
{
  internal readonly FactoryDict Generators = [];
  internal readonly FactoryList TypeGenerators = [];

  public IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IGqlpError
    => this.FluentAction(b => b.Generators[typeof(TAst)] = factory);

  public IGeneratorRepositoryBuilder AddTypeGenerator(Factory<ITypeGenerator, IGeneratorRepository> factory)
    => this.FluentAction(b => b.TypeGenerators.Add(factory));
}
