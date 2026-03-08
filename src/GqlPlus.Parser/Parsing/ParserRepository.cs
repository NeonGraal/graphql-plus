using System.Collections.Concurrent;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus.Parsing;

internal class ParserRepository(
  ParserRepositoryBuilder builder
) : IParserRepository
{
  private readonly ConcurrentDictionary<Type, object> _cache = new();

  private object Cached(FactoryDict factories, Type factoryKey, Type cacheKey, string label)
    => _cache.GetOrAdd(
      cacheKey,
      _ => {
        if (factories.TryGetValue(factoryKey, out ParserFactory<object>? factory)) {
          return factory.Invoke(this);
        }

        throw new InvalidOperationException($"No {label} parser registration found for type '{factoryKey.TidyTypeName()}'.");
      });

  private TCache Cached<TKey, TCache>(FactoryDict factories, string label)
    => (TCache)Cached(factories, typeof(TKey), typeof(TCache), label);

  public Parser<T>.L ParserFor<T>()
    => new(() => Cached<T, Parser<T>.I>(builder.Singles, "single"));

  public Parser<T>.LA ArrayFor<T>()
    => new(() => Cached<T, Parser<T>.IA>(builder.Arrays, "array"));

  public Parser<TInterface, TFor>.L ParserFor<TInterface, TFor>()
    where TInterface : class, Parser<TFor>.I
    => new(() => Cached<TInterface, TInterface>(builder.InterfaceSingles, "interface"));

  public ParserArray<TInterface, TFor>.LA ArrayFor<TInterface, TFor>()
    where TInterface : class, Parser<TFor>.IA
    => new(() => Cached<TInterface, TInterface>(builder.InterfaceArrays, "interface array"));

  public IEnumerable<IParseDeclaration> GetDeclarations()
    => builder.Declarations.Select(f => (IParseDeclaration)_cache.GetOrAdd(f.Key, _ => f.Value.Invoke(this)));

  public IEnumerable<IParseDomain> GetDomains()
    => builder.Domains.Select(t => (IParseDomain)Cached(builder.Singles, t.Key, t.Value, "domain"));
  public T GetName<T>()
    where T : INameParser
    => Cached<T, T>(builder.InterfaceSingles, "name");
}
