namespace GqlPlus.Modelling;

internal interface IModellerRepositoryBuilder
{
  IModellerRepositoryBuilder AddModeller<TAst, TModel>(Factory<IModeller<TAst, TModel>, IModellerRepository> factory)
    where TAst : class, IAstError
    where TModel : class, IModelBase;

  IModellerRepositoryBuilder AddTypeModeller<TAst, TModel>(Factory<ITypeModeller<TAst, TModel>, IModellerRepository> factory)
    where TAst : class, IAstError
    where TModel : class, IModelBase;

  IModellerRepositoryBuilder AddModifierModeller(Factory<IModifierModeller, IModellerRepository> factory);
  IModellerRepositoryBuilder AddTypesModeller(Factory<ITypesModeller, IModellerRepository> factory);
}
