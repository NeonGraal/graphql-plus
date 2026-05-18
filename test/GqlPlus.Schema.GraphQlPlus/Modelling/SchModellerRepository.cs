using System;
using System.Collections.Concurrent;

namespace GqlPlus.Schema.Modelling;

internal class SchModellerRepository(SchModellerRepositoryBuilder builder)
  : ISchModellerRepository
{
  private readonly ConcurrentDictionary<Type, object> _cache = new ConcurrentDictionary<Type, object>();

  public Modeller<TAst, TModel>.D ModellerFor<TAst, TModel>()
    where TAst : class
    where TModel : class
    => () => (IModeller<TAst, TModel>)_cache.GetOrAdd(
      typeof(IModeller<TAst, TModel>),
      _ => builder.Factories[typeof(IModeller<TAst, TModel>)](this));
}
