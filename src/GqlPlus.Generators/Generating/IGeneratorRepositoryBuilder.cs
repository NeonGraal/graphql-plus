using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGeneratorRepositoryBuilder
{
  IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IGqlpError;

  IGeneratorRepositoryBuilder AddTypeGenerator(Factory<ITypeGenerator, IGeneratorRepository> factory);
}
