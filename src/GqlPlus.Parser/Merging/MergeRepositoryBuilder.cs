using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GqlPlus.Merging;

internal class MergeRepositoryBuilder
  : IMergeRepositoryBuilder
{
  // Maps value type T (in IMerge<T>) -> service type key for cache
  internal readonly Dictionary<Type, Type> MergerTypes = [];

  // Maps service type -> factory (for creating instances)
  internal readonly Dictionary<Type, MergerFactory<object>> Factories = [];

  // Maps AST type T (in IMergeAll<T>) -> list of service types
  internal readonly Dictionary<Type, List<Type>> AllMergerTypes = [];

  // DI registration actions for backward-compat IMerge<T> registrations
  internal readonly List<Action<IServiceCollection>> DiRegistrations = [];

  public IMergeRepositoryBuilder AddMerge<T>(MergerFactory<IMerge<T>> factory)
    where T : IGqlpError
  {
    MergerTypes[typeof(T)] = typeof(T);
    Factories[typeof(T)] = m => factory(m);
    DiRegistrations.Add(s => s
      .RemoveAll<IMerge<T>>()
      .AddSingleton<IMerge<T>>(sp => sp.GetRequiredService<IMergerRepository>().MergerFor<T>()));
    return this;
  }

  public IMergeRepositoryBuilder AddMergeAll<TAst, TType, TService>(MergerFactory<TService> factory)
    where TAst : IGqlpType
    where TType : IGqlpType
    where TService : class, IMergeAll<TType>, IMerge<TAst>
  {
    MergerTypes[typeof(TAst)] = typeof(TService);
    Factories[typeof(TService)] = m => factory(m);
    if (!AllMergerTypes.TryGetValue(typeof(TType), out List<Type>? list)) {
      list = [];
      AllMergerTypes[typeof(TType)] = list;
    }

    if (!list.Contains(typeof(TService))) {
      list.Add(typeof(TService));
    }

    DiRegistrations.Add(s => s
      .RemoveAll<IMerge<TAst>>()
      .AddSingleton<IMerge<TAst>>(sp => sp.GetRequiredService<IMergerRepository>().MergerFor<TAst>()));
    return this;
  }

  internal void RegisterDiServices(IServiceCollection services)
  {
    foreach (Action<IServiceCollection> registration in DiRegistrations) {
      registration(services);
    }
  }
}
