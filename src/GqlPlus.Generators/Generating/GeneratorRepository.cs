using GqlPlus.Ast;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Generating;

internal class GeneratorRepository
  : BaseRepository<IGeneratorRepository>
  , IGeneratorRepository
{
  private readonly GeneratorRepositoryBuilder _builder;
  private readonly Lazy<IDictionary<GqlpGeneratorType, IEnumerable<ITypeGenerator>>> _typeGenerators;

  public GeneratorRepository(GeneratorRepositoryBuilder builder, ILoggerFactory loggerFactory)
    : base(loggerFactory)
  {
    _builder = builder;
    _typeGenerators = new(() => builder.TypeGenerators
      .ToDictionary(kv => kv.Key, kv => (IEnumerable<ITypeGenerator>)[.. kv.Value.Select(f => f(this))]));
  }

  public IGenerator<TAst> GeneratorFor<TAst>()
    where TAst : IAstError
    => Cached<TAst, IGenerator<TAst>>(_builder.Generators, "generator", this);

  public IDictionary<GqlpGeneratorType, IEnumerable<ITypeGenerator>> TypeGenerators => _typeGenerators.Value;
}
