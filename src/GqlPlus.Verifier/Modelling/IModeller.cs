using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal interface IModeller<TAst>
  where TAst : AstBase
{
  IRendering ToRenderer(TAst ast);
  T? TryModel<T>(TAst? ast);
  T ToModel<T>(TAst? ast);
  IEnumerable<T?> TryModels<T>(IEnumerable<TAst>? asts);
  T[] ToModels<T>(IEnumerable<TAst>? asts);
}
