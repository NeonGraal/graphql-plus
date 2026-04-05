using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGeneratorRepository
{
  IGenerator<TAst> GeneratorFor<TAst>()
    where TAst : IGqlpError;

  IDictionary<GqlpGeneratorType, IEnumerable<ITypeGenerator>> TypeGenerators { get; }
}
