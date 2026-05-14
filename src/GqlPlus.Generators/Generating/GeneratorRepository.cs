using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using GqlPlus.Ast;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Generating;

internal class GeneratorRepository(
  GeneratorRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : BaseRepository<IGeneratorRepository>(loggerFactory)
  , IGeneratorRepository
{
  private readonly ConcurrentDictionary<GqlpGeneratorType, IEnumerable<ITypeGenerator>> _typeGenerators = [];

  public Generator<TAst>.D GeneratorFor<TAst>([CallerMemberName] string callerName = "")
    where TAst : IAstError
    => () => Cached<TAst, IGenerator<TAst>>(builder.Generators, "generator for " + callerName, this);

  public DeferList<ITypeGenerator>.D TypeGenerators(GqlpGeneratorType generatorType, [CallerMemberName] string callerName = "")
    => () => _typeGenerators.GetOrAdd(generatorType, k
        => [.. InstancesFor<ITypeGenerator>(
          builder.TypeGenerators.GetValueOr(k, []),
          this)]);
}
