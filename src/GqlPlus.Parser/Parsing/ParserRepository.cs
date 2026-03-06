using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Parsing;

internal class ParserRepository(
  IServiceProvider services,
  IEnumerable<ParserRegistration> registrations
) : IParserRepository
{
  private readonly Dictionary<Type, Type> _singles = registrations
    .Where(r => r.Kind == ParserRegistrationKind.Single)
    .GroupBy(r => r.For)
    .ToDictionary(g => g.Key, g => g.Last().Service);
  private readonly Dictionary<Type, Type> _arrays = registrations
    .Where(r => r.Kind == ParserRegistrationKind.Array)
    .GroupBy(r => r.For)
    .ToDictionary(g => g.Key, g => g.Last().Service);
  private readonly Dictionary<Type, Type> _interfaceSingles = registrations
    .Where(r => r.Kind == ParserRegistrationKind.SingleInterface)
    .GroupBy(r => r.For)
    .ToDictionary(g => g.Key, g => g.Last().Service);
  private readonly Dictionary<Type, Type> _interfaceArrays = registrations
    .Where(r => r.Kind == ParserRegistrationKind.ArrayInterface)
    .GroupBy(r => r.For)
    .ToDictionary(g => g.Key, g => g.Last().Service);

  private readonly ConcurrentDictionary<Type, object> _cache = new();

  public Parser<T>.L Get<T>()
    => (Parser<T>.L)_cache.GetOrAdd(
      typeof(Parser<T>.I),
      _ => {
        if (!_singles.TryGetValue(typeof(T), out Type? service)) {
          throw new InvalidOperationException($"No parser registration found for type '{typeof(T).FullName}'.");
        }
        return new Parser<T>.L(() => (Parser<T>.I)services.GetRequiredService(service));
      });

  public Parser<T>.LA GetArray<T>()
    => (Parser<T>.LA)_cache.GetOrAdd(
      typeof(Parser<T>.IA),
      _ => {
        if (!_arrays.TryGetValue(typeof(T), out Type? service)) {
          throw new InvalidOperationException($"No array parser registration found for type '{typeof(T).FullName}'.");
        }
        return new Parser<T>.LA(() => (Parser<T>.IA)services.GetRequiredService(service));
      });

  public Parser<TInterface, T>.L GetInterface<TInterface, T>()
    where TInterface : class, Parser<T>.I
    => (Parser<TInterface, T>.L)_cache.GetOrAdd(
      typeof(Parser<TInterface, T>.L),
      _ => {
        if (!_interfaceSingles.TryGetValue(typeof(TInterface), out Type? service)) {
          throw new InvalidOperationException($"No interface parser registration found for type '{typeof(TInterface).FullName}'.");
        }
        return new Parser<TInterface, T>.L(() => (TInterface)services.GetRequiredService(service));
      });

  public ParserArray<TInterface, T>.LA GetArrayInterface<TInterface, T>()
    where TInterface : class, Parser<T>.IA
    => (ParserArray<TInterface, T>.LA)_cache.GetOrAdd(
      typeof(ParserArray<TInterface, T>.LA),
      _ => {
        if (!_interfaceArrays.TryGetValue(typeof(TInterface), out Type? service)) {
          throw new InvalidOperationException($"No interface array parser registration found for type '{typeof(TInterface).FullName}'.");
        }
        return new ParserArray<TInterface, T>.LA(() => (TInterface)services.GetRequiredService(service));
      });
}
