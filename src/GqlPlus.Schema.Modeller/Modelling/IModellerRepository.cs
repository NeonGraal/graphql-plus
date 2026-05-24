using System.Runtime.CompilerServices;

namespace GqlPlus.Modelling;

public interface IModellerRepository
  : IRepository
{
  Modeller<TAst, TModel>.D ModellerFor<TAst, TModel>([CallerMemberName] string callerName = "")
    where TAst : IAstError
    where TModel : IModelBase;

  DeferOne<IModifierModeller>.D ModifierModeller([CallerMemberName] string callerName = "");
  DeferOne<ITypesModeller>.D TypesModeller([CallerMemberName] string callerName = "");
  DeferList<ITypeModeller>.D TypeModellers([CallerMemberName] string callerName = "");
}
