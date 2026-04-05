using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal class GeneratorRepositoryBuilder
  : BaseFactory<IGeneratorRepository>, IGeneratorRepositoryBuilder
{
  internal readonly FactoryDict Generators = [];
  internal readonly Dictionary<GqlpGeneratorType, List<ITypeGenerator>> TypeGenerators = [];

  public IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IGqlpError
    => this.FluentAction(b => b.Generators[typeof(TAst)] = factory);

  public IGeneratorRepositoryBuilder AddTypeGenerator(GqlpGeneratorType generatorType, ITypeGenerator generator)
    => this.FluentAction(b => {
      if (!b.TypeGenerators.TryGetValue(generatorType, out List<ITypeGenerator>? list)) {
        b.TypeGenerators[generatorType] = list = [];
      }
      list.Add(generator);
    });
}
