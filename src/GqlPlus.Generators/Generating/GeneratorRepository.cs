using GqlPlus.Abstractions;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Generating;

internal class GeneratorRepository
  : BaseRepository<IGeneratorRepository>
  , IGeneratorRepository
{
  private readonly GeneratorRepositoryState _state;
  private readonly Lazy<IEnumerable<ITypeGenerator>> _typeGenerators;

  public GeneratorRepository(GeneratorRepositoryState state, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _state = state;
    _typeGenerators = new(() => [.. state.TypeGeneratorFactories.Select(f => f(this))]);
  }

  public IGenerator<TAst> GeneratorFor<TAst>()
    where TAst : IGqlpError
    => Cached<TAst, IGenerator<TAst>>(_state.Generators, "generator", this);

  public IEnumerable<ITypeGenerator> TypeGenerators => _typeGenerators.Value;
}
