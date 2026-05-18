namespace GqlPlus.Schema.Modelling;

public interface ISchModellerRepositoryBuilder
{
  ISchModellerRepositoryBuilder AddModeller<TAst, TModel>(Func<ISchModellerRepository, IModeller<TAst, TModel>> factory)
    where TAst : class
    where TModel : class;
}
