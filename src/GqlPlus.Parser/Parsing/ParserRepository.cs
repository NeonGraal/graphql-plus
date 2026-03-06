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
    .ToDictionary(r => r.For, r => r.Service);
  private readonly Dictionary<Type, Type> _arrays = registrations
    .Where(r => r.Kind == ParserRegistrationKind.Array)
    .ToDictionary(r => r.For, r => r.Service);
  private readonly Dictionary<Type, Type> _interfaceSingles = registrations
    .Where(r => r.Kind == ParserRegistrationKind.SingleInterface)
    .ToDictionary(r => r.For, r => r.Service);
  private readonly Dictionary<Type, Type> _interfaceArrays = registrations
    .Where(r => r.Kind == ParserRegistrationKind.ArrayInterface)
    .ToDictionary(r => r.For, r => r.Service);

  private readonly ConcurrentDictionary<Type, object> _cache = new();

  public Parser<T>.L Get<T>()
    => (Parser<T>.L)_cache.GetOrAdd(
      typeof(Parser<T>.I),
      _ => new Parser<T>.L(() => (Parser<T>.I)services.GetRequiredService(_singles[typeof(T)])));

  public Parser<T>.LA GetArray<T>()
    => (Parser<T>.LA)_cache.GetOrAdd(
      typeof(Parser<T>.IA),
      _ => new Parser<T>.LA(() => (Parser<T>.IA)services.GetRequiredService(_arrays[typeof(T)])));

  public Parser<TInterface, T>.L GetInterface<TInterface, T>()
    where TInterface : class, Parser<T>.I
    => (Parser<TInterface, T>.L)_cache.GetOrAdd(
      typeof(Parser<TInterface, T>.L),
      _ => new Parser<TInterface, T>.L(() => (TInterface)services.GetRequiredService(_interfaceSingles[typeof(TInterface)])));

  public ParserArray<TInterface, T>.LA GetArrayInterface<TInterface, T>()
    where TInterface : class, Parser<T>.IA
    => (ParserArray<TInterface, T>.LA)_cache.GetOrAdd(
      typeof(ParserArray<TInterface, T>.LA),
      _ => new ParserArray<TInterface, T>.LA(() => (TInterface)services.GetRequiredService(_interfaceArrays[typeof(TInterface)])));
}
