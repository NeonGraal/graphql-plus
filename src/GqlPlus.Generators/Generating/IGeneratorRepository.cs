using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGeneratorRepository
{
  IGenerator<TAst> GeneratorFor<TAst>()
    where TAst : IAstError;

  IEnumerable<ITypeGenerator> TypeGenerators(GqlpGeneratorType generatorType);
}
