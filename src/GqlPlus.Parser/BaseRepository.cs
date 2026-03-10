using System.Collections.Concurrent;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema;
using GqlPlus.Parsing.Schema.Simple;

namespace GqlPlus;

public class BaseRepository<TRepo>
  : BaseFactory<TRepo>
{
  private readonly ConcurrentDictionary<Type, object> _cache = new();

  protected object Cached(FactoryDict factories, Type factoryKey, Type cacheKey, string label, TRepo repo)
    => _cache.GetOrAdd(
      cacheKey,
      _ => {
        if (factories.TryGetValue(factoryKey, out Factory<object, TRepo>? factory)) {
          return factory.Invoke(repo);
        }

        throw new InvalidOperationException($"No {label} registration found for type '{factoryKey.TidyTypeName()}'.");
      });

  protected TResult Cached<TKey, TResult>(FactoryDict factories, string label, TRepo repo)
    => (TResult)Cached(factories, typeof(TKey), typeof(TResult), label, repo);
}

#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
public class BaseFactory<TRepo>
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
{
#pragma warning disable CA1034 // Nested types should not be visible
  public class FactoryDict : Dictionary<Type, Factory<object, TRepo>>;
#pragma warning restore CA1034 // Nested types should not be visible
}

public delegate T Factory<out T, TRepo>(TRepo parsers)
  where T : class;
