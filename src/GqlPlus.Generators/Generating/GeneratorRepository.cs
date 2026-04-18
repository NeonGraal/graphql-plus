using System.Collections.Concurrent;
using GqlPlus.Abstractions;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Generating;

internal class GeneratorRepository(
  GeneratorRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IGeneratorRepository>(loggerFactory)
  , IGeneratorRepository
{
  private readonly ConcurrentDictionary<GqlpGeneratorType, IEnumerable<ITypeGenerator>> _typeGenerators = [];

  public IGenerator<TAst> GeneratorFor<TAst>()
    where TAst : IAstError
    => Cached<TAst, IGenerator<TAst>>(builder.Generators, "generator", this);

  public IEnumerable<ITypeGenerator> TypeGenerators(GqlpGeneratorType generatorType)
    => _typeGenerators.GetOrAdd(
      generatorType,
      k => [.. builder.TypeGenerators
        .GetValueOrDefault(k, [])
        .Select(f => (ITypeGenerator)f(this))]);
}
