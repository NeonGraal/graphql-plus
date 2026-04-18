using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal class GeneratorRepositoryBuilder
  : BaseFactory<IGeneratorRepository>, IGeneratorRepositoryBuilder
{
  internal readonly FactoryDict Generators = [];

  // Factory<ITypeGenerator, IGeneratorRepository>
  internal readonly Dictionary<GqlpGeneratorType, FactoryList> TypeGenerators = [];

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
      .AddTypeGenerator<TDecoder>(GqlpGeneratorType.Decoder)
      .AddTypeGenerator<TEncoder>(GqlpGeneratorType.Encoder);

  public IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IAstError
    => this.FluentAction(b => b.Generators[typeof(TAst)] = factory);
  public IGeneratorRepositoryBuilder AddGenerator<TAst, TGenerator>()
    where TAst : IAstError
    where TGenerator : IGenerator<TAst>, new()
    => AddGenerator(_ => new TGenerator());

  public IGeneratorRepositoryBuilder AddTypeGenerator<TGenerator>(GqlpGeneratorType generatorType)
    where TGenerator : ITypeGenerator, new()
    => this.FluentAction(b => {
      FactoryList list = b.TypeGenerators.GetValueOrCreate(generatorType, _ => []);
      list.Add(_ => new TGenerator());
    });
}
