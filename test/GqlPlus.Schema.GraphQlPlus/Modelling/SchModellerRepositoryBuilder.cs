using System;
using System.Collections.Generic;

namespace GqlPlus.Schema.Modelling;

internal class SchModellerRepositoryBuilder
{
  internal readonly Dictionary<Type, Func<ISchModellerRepository, object>> Factories = [];

  internal SchModellerRepositoryBuilder AddModeller<TAst, TModel>(Func<ISchModellerRepository, IModeller<TAst, TModel>> factory)
    where TAst : class
    where TModel : class
  {
    Factories[typeof(IModeller<TAst, TModel>)] = repo => factory(repo);
    return this;
  }
}
