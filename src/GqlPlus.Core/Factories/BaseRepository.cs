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
          : throw new InvalidOperationException($"No {label} registration found for type '{factoryKey.TidyTypeName()}'."));

  protected TResult Cached<TKey, TResult>(FactoryDict factories, string label, TRepo repo)
    => (TResult)Cached(factories, typeof(TKey), typeof(TResult), label, repo);
}
