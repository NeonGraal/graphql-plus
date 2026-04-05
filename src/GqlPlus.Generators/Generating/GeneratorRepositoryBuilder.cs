using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal class GeneratorRepositoryBuilder
  : BaseFactory<IGeneratorRepository>, IGeneratorRepositoryBuilder
{
  internal readonly FactoryDict Generators = [];
  internal readonly Dictionary<GqlpGeneratorType, List<Factory<ITypeGenerator, IGeneratorRepository>>> TypeGenerators = [];

  public IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IGqlpError
    => this.FluentAction(b => b.Generators[typeof(TAst)] = factory);

  public IGeneratorRepositoryBuilder AddTypeGenerator(GqlpGeneratorType generatorType, Factory<ITypeGenerator, IGeneratorRepository> factory)
    => this.FluentAction(b => {
      if (b.TypeGenerators.TryGetValue(generatorType, out List<Factory<ITypeGenerator, IGeneratorRepository>>? list)) {
        list.Add(factory);
      } else {
        b.TypeGenerators[generatorType] = [factory];
      }
    });
}
