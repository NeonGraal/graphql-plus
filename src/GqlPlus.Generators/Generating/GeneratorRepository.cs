using GqlPlus.Abstractions;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Generating;

internal class GeneratorRepository
  : BaseRepository<IGeneratorRepository>
  , IGeneratorRepository
{
  private readonly GeneratorRepositoryBuilder _builder;
  private readonly Lazy<IEnumerable<ITypeGenerator>> _typeGenerators;

  public GeneratorRepository(GeneratorRepositoryBuilder builder, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _builder = builder;
    _typeGenerators = new(() =>
      [.. builder.TypeGenerators.Select(f => (ITypeGenerator)f(this))]);
  }

  public IGenerator<TAst> GeneratorFor<TAst>()
    where TAst : IGqlpError
    => Cached<TAst, IGenerator<TAst>>(_builder.Generators, "generator", this);

  public IEnumerable<ITypeGenerator> TypeGenerators => _typeGenerators.Value;
}
