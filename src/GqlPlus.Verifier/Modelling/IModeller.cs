using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public interface IModeller<TAst>
  where TAst : AstBase
{
  IRendering ToRenderer(TAst ast);
  T? TryModel<T>(TAst? ast);
  T ToModel<T>(TAst? ast);
  IEnumerable<T?> TryModels<T>(IEnumerable<TAst>? asts);
  T[] ToModels<T>(IEnumerable<TAst>? asts);
}

public interface IModeller<TAst, TModel>
  : IModeller<TAst>
  where TAst : AstBase
{
  TModel? TryModel(TAst? ast);
  TModel ToModel(TAst? ast);
  IEnumerable<TModel?> TryModels(IEnumerable<TAst>? asts);
  TModel[] ToModels(IEnumerable<TAst>? asts);
}
