using GqlPlus.Abstractions;

namespace GqlPlus.Generating;

internal interface IGeneratorRepository
{
  IGenerator<TAst> GeneratorFor<TAst>()
    where TAst : IAstError;

  IDictionary<GqlpGeneratorType, IEnumerable<ITypeGenerator>> TypeGenerators { get; }
}
