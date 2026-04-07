using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGeneratorRepositoryBuilder
{
  IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IGqlpError;
  IGeneratorRepositoryBuilder AddGenerator<TAst, TGenerator>()
    where TAst : IGqlpError
    where TGenerator : IGenerator<TAst>, new();

  IGeneratorRepositoryBuilder AddTypeGenerator<TGenerator>(GqlpGeneratorType generatorType)
    where TGenerator : ITypeGenerator, new();

  IGeneratorRepositoryBuilder AddBothTypeGenerators<TInterface, TModel>()
    where TInterface : ITypeGenerator, new() where TModel : ITypeGenerator, new();
}
