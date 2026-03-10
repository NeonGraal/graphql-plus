using System.Collections.Concurrent;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

internal class MergerRepository(
  MergeRepositoryBuilder builder,
  ILoggerFactory loggerFactory
) : IMergerRepository
{
  private readonly ConcurrentDictionary<Type, object> _cache = new();

  public ILoggerFactory LoggerFactory => loggerFactory;

  public IMerge<T> MergerFor<T>()
    where T : IGqlpError
    => (IMerge<T>)_cache.GetOrAdd(
      GetServiceType<T>(),
      serviceType => CreateInstance(serviceType));

  public IEnumerable<IMergeAll<T>> AllMergersFor<T>()
    where T : IGqlpType
  {
    if (builder.AllMergerTypes.TryGetValue(typeof(T), out List<Type>? serviceTypes)) {
      return serviceTypes.Select(serviceType =>
        (IMergeAll<T>)_cache.GetOrAdd(serviceType, st => CreateInstance(st)));
    }

    return [];
  }

  private Type GetServiceType<T>()
    where T : IGqlpError
  {
    if (builder.MergerTypes.TryGetValue(typeof(T), out Type? serviceType)) {
      return serviceType;
    }

    throw new InvalidOperationException($"No merger registered for type '{typeof(T).TidyTypeName()}'.");
  }

  private object CreateInstance(Type serviceType)
  {
    if (builder.Factories.TryGetValue(serviceType, out MergerFactory<object>? factory)) {
      return factory(this);
    }

    throw new InvalidOperationException($"No factory registered for merger service type '{serviceType.TidyTypeName()}'.");
  }
}
