using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Factories;

public class BaseRepository<TRepo>(
  ILoggerFactory loggerFactory
) : BaseFactory<TRepo>
  , IRepository
  where TRepo : IRepository
{
  public ILoggerFactory LoggerFactory { get; } = loggerFactory;

  private readonly ConcurrentDictionary<Type, object> _cache = new();

  protected object Cached(FactoryDict factories, Type factoryKey, Type cacheKey, string label, TRepo repo)
    => _cache.GetOrAdd(
      cacheKey,
      _ => factories
        .TryGetValue(factoryKey, out Factory<object, TRepo>? factory)
          ? factory.Invoke(repo)
          : new InvalidOperationException($"No {label} registration found for type '{factoryKey.TidyTypeName()}'."));

  protected TResult Cached<TKey, TResult>(FactoryDict factories, string label, TRepo repo)
    => (TResult)Cached(factories, typeof(TKey), typeof(TResult), label, repo);
}

public interface IRepository
{
  ILoggerFactory LoggerFactory { get; }
}

#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
public class BaseFactory<TRepo>
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
{
#pragma warning disable CA1034 // Nested types should not be visible
  public class FactoryDict : Dictionary<Type, Factory<object, TRepo>>;
  public class FactoryList : List<Factory<object, TRepo>>;
#pragma warning restore CA1034 // Nested types should not be visible

  protected KeyValuePair<Type, Factory<object, TRepo>> FactoryKeyValue<T>(Factory<object, TRepo> factory)
    => factory.ToKeyValue(typeof(T));
}
