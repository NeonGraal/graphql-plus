namespace GqlPlus.Schema.Modelling;

public interface ISchModellerRepository
{
  Modeller<TAst, TModel>.D ModellerFor<TAst, TModel>()
    where TAst : class
    where TModel : class;
}
