using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public interface IModeller<TAst>
  where TAst : AstBase
{
  IRendering ToRenderer(TAst ast, IMap<TypeKindModel> typeKinds);
  T? TryModel<T>(TAst? ast, IMap<TypeKindModel> typeKinds);
  T ToModel<T>(TAst? ast, IMap<TypeKindModel> typeKinds);
  IEnumerable<T?> TryModels<T>(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds);
  T[] ToModels<T>(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds);
}

public interface IModeller<TAst, TModel>
  : IModeller<TAst>
  where TAst : AstBase
{
  TModel? TryModel(TAst? ast, IMap<TypeKindModel> typeKinds);
  TModel ToModel(TAst? ast, IMap<TypeKindModel> typeKinds);
  IEnumerable<TModel?> TryModels(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds);
  TModel[] ToModels(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds);
}
