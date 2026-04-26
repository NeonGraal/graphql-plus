namespace GqlPlus.Modelling;

internal interface IModellerRepository
{
  IModeller<TAst, TModel> ModellerFor<TAst, TModel>()
    where TAst : IAstError
    where TModel : IModelBase;

  IModifierModeller ModifierModeller { get; }
  ITypesModeller TypesModeller { get; }
  IEnumerable<ITypeModeller> TypeModellers { get; }
}
