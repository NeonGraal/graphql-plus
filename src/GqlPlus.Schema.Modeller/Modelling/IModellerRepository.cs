using System.Runtime.CompilerServices;

namespace GqlPlus.Modelling;

internal interface IModellerRepository
  : IRepository
{
  Defer<IModeller<TAst, TModel>>.D ModellerFor<TAst, TModel>([CallerMemberName] string callerName = "")
    where TAst : IAstError
    where TModel : IModelBase;

  Defer<IModifierModeller>.D ModifierModeller([CallerMemberName] string callerName = "");
  Defer<ITypesModeller>.D TypesModeller([CallerMemberName] string callerName = "");
  Defer<ITypeModeller>.DA TypeModellers([CallerMemberName] string callerName = "");
}
