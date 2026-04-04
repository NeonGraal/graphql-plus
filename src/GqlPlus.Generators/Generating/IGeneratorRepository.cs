using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGeneratorRepository
{
  IGenerator<TAst> GeneratorFor<TAst>()
    where TAst : IGqlpError;

  IEnumerable<ITypeGenerator> TypeGenerators { get; }
}
