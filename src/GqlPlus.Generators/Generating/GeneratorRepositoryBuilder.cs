using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal class GeneratorRepositoryBuilder
  : BaseFactory<IGeneratorRepository>, IGeneratorRepositoryBuilder
{
  internal readonly FactoryDict Generators = [];
  internal readonly Dictionary<GqlpGeneratorType, List<Factory<ITypeGenerator, IGeneratorRepository>>> TypeGenerators = [];

  public IGeneratorRepositoryBuilder AddBothTypeGenerators<TInterface, TModel>()
    where TInterface : ITypeGenerator, new()
    where TModel : ITypeGenerator, new()
    => AddTypeGenerator<TInterface>(GqlpGeneratorType.Interface)
      .AddTypeGenerator<TModel>(GqlpGeneratorType.Model);

  public IGeneratorRepositoryBuilder AddAllFourTypeGenerators<TInterface, TModel, TDecoder, TEncoder>()
    where TInterface : ITypeGenerator, new()
    where TModel : ITypeGenerator, new()
    where TDecoder : ITypeGenerator, new()
    where TEncoder : ITypeGenerator, new()
    => AddBothTypeGenerators<TInterface, TModel>()
      .AddTypeGenerator<TDecoder>(GqlpGeneratorType.Dec)
      .AddTypeGenerator<TEncoder>(GqlpGeneratorType.Enc);

  public IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IGqlpError
    => this.FluentAction(b => b.Generators[typeof(TAst)] = factory);
  public IGeneratorRepositoryBuilder AddGenerator<TAst, TGenerator>()
    where TAst : IGqlpError
    where TGenerator : IGenerator<TAst>, new()
    => AddGenerator(_ => new TGenerator());

  public IGeneratorRepositoryBuilder AddTypeGenerator<TGenerator>(GqlpGeneratorType generatorType)
    where TGenerator : ITypeGenerator, new()
    => this.FluentAction(b => {
      if (b.TypeGenerators.TryGetValue(generatorType, out List<Factory<ITypeGenerator, IGeneratorRepository>>? list)) {
        list.Add(_ => new TGenerator());
      } else {
        b.TypeGenerators[generatorType] = [_ => new TGenerator()];
      }
    });
}
