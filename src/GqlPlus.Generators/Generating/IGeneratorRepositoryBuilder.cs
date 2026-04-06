using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGeneratorRepositoryBuilder
{
  IGeneratorRepositoryBuilder AddGenerator<TAst>(Factory<IGenerator<TAst>, IGeneratorRepository> factory)
    where TAst : IGqlpError;

  IGeneratorRepositoryBuilder AddTypeGenerator(GqlpGeneratorType generatorType, Factory<ITypeGenerator, IGeneratorRepository> factory);
  IGeneratorRepositoryBuilder AddBothTypeGenerators(Factory<ITypeGenerator, IGeneratorRepository> interfaceFactory, Factory<ITypeGenerator, IGeneratorRepository> modelFactory);
}
