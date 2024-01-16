using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal interface IModeller<TAst>
  where TAst : AstBase
{
  IRendering ToRenderer(TAst ast);
  T? ToModel<T>(TAst? ast);
}
