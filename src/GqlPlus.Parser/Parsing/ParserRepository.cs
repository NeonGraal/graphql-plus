using System.Collections.Concurrent;
using GqlPlus.Parsing.Schema.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

internal class ParserRepository(
  IServiceProvider services,
  ParserRepositoryBuilder builder
) : IParserRepository, IDomainParserRepository
{
  private readonly ConcurrentDictionary<Type, object> _parserInstances = new();
  private readonly ConcurrentDictionary<Type, object> _cache = new();

  private TService CreateInstance<TService>(Type serviceType)
    where TService : class
    => (TService)_parserInstances.GetOrAdd(serviceType, t => ActivatorUtilities.GetServiceOrCreateInstance(services, t));

  public IEnumerable<IParseDomain> GetDomains()
    => builder.Domains.Select(t => CreateInstance<IParseDomain>(t));

  public Parser<T>.L Get<T>()
    => (Parser<T>.L)_cache.GetOrAdd(
      typeof(Parser<T>.I),
      _ => {
        if (!builder.Singles.TryGetValue(typeof(T), out Type? service)) {
          throw new InvalidOperationException($"No parser registration found for type '{typeof(T).FullName}'.");
        }
        return new Parser<T>.L(() => CreateInstance<Parser<T>.I>(service));
      });

  public Parser<T>.LA GetArray<T>()
    => (Parser<T>.LA)_cache.GetOrAdd(
      typeof(Parser<T>.IA),
      _ => {
        if (!builder.Arrays.TryGetValue(typeof(T), out Type? service)) {
          throw new InvalidOperationException($"No array parser registration found for type '{typeof(T).FullName}'.");
        }
        return new Parser<T>.LA(() => CreateInstance<Parser<T>.IA>(service));
      });

  public Parser<TInterface, T>.L GetInterface<TInterface, T>()
    where TInterface : class, Parser<T>.I
    => (Parser<TInterface, T>.L)_cache.GetOrAdd(
      typeof(Parser<TInterface, T>.L),
      _ => {
        if (!builder.InterfaceSingles.TryGetValue(typeof(TInterface), out Type? service)) {
          throw new InvalidOperationException($"No interface parser registration found for type '{typeof(TInterface).FullName}'.");
        }
        return new Parser<TInterface, T>.L(() => CreateInstance<TInterface>(service));
      });

  public ParserArray<TInterface, T>.LA GetArrayInterface<TInterface, T>()
    where TInterface : class, Parser<T>.IA
    => (ParserArray<TInterface, T>.LA)_cache.GetOrAdd(
      typeof(ParserArray<TInterface, T>.LA),
      _ => {
        if (!builder.InterfaceArrays.TryGetValue(typeof(TInterface), out Type? service)) {
          throw new InvalidOperationException($"No interface array parser registration found for type '{typeof(TInterface).FullName}'.");
        }
        return new ParserArray<TInterface, T>.LA(() => CreateInstance<TInterface>(service));
      });
}
