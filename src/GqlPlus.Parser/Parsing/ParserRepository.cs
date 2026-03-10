using System.Collections.Concurrent;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

internal class ParserRepository(
  ParserRepositoryBuilder builder
) : BaseRepository<IParserRepository>, IParserRepository
{
  private readonly ConcurrentDictionary<Type, object> _cache = new();

  public Parser<T>.L ParserFor<T>()
    => new(() => Cached<T, Parser<T>.I>(builder.Singles, "single parser", this));

  public Parser<T>.LA ArrayFor<T>()
    => new(() => Cached<T, Parser<T>.IA>(builder.Arrays, "array parser", this));

  public Parser<TInterface, TFor>.L ParserFor<TInterface, TFor>()
    where TInterface : class, Parser<TFor>.I
    => new(() => Cached<TInterface, TInterface>(builder.InterfaceSingles, "interface parser", this));

  public ParserArray<TInterface, TFor>.LA ArrayFor<TInterface, TFor>()
    where TInterface : class, Parser<TFor>.IA
    => new(() => Cached<TInterface, TInterface>(builder.InterfaceArrays, "interface array parser", this));

  public IEnumerable<IParseDeclaration> GetDeclarations()
    => builder.Declarations.Select(f => (IParseDeclaration)_cache.GetOrAdd(f.Key, _ => f.Value.Invoke(this)));

  public IEnumerable<IParseDomain> GetDomains()
    => builder.Domains.Select(t => (IParseDomain)Cached(builder.Singles, t.Key, t.Value, "domain parser", this));
  public T GetName<T>()
    where T : INameParser
    => Cached<T, T>(builder.InterfaceSingles, "name parser", this);
}
