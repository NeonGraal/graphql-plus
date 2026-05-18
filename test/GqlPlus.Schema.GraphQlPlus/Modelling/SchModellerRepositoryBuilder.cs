namespace GqlPlus.Schema.Modelling;

internal class SchModellerRepositoryBuilder
  : ISchModellerRepositoryBuilder
{
  internal readonly Dictionary<Type, Func<ISchModellerRepository, object>> Factories = [];

  public ISchModellerRepositoryBuilder AddModeller<TAst, TModel>(Func<ISchModellerRepository, IModeller<TAst, TModel>> factory)
    where TAst : class
    where TModel : class
  {
    Factories[typeof(IModeller<TAst, TModel>)] = repo => factory(repo);
    return this;
  }
}
