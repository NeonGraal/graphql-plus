using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal class GeneratorRepositoryBuilder
  : BaseFactory<IGeneratorRepository>, IGeneratorRepositoryBuilder
{
  internal readonly FactoryDict Generators = [];
  internal readonly List<Factory<ITypeGenerator, IGeneratorRepository>> TypeGeneratorFactories = [];

  public IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IGqlpError
    => this.FluentAction(b => b.Generators[typeof(TAst)] = factory);

  public IGeneratorRepositoryBuilder AddTypeGenerator(Factory<ITypeGenerator, IGeneratorRepository> factory)
    => this.FluentAction(b => b.TypeGeneratorFactories.Add(factory));

  internal GeneratorRepositoryState Build()
    => new(Generators, TypeGeneratorFactories);
}
