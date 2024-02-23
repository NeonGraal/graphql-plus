using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract class ModellerType<TAst, TModel>
  : ModellerBase<TAst, TModel>, IModeller<AstType<string>>
  where TAst : AstType<string>
  where TModel : IRendering
{
  T? IModeller<AstType<string>>.ToModel<T>(AstType<string>? ast)
    where T : default
    => ToModel<T>((TAst?)ast);

  IRendering IModeller<AstType<string>>.ToRenderer(AstType<string> ast)
    => ToRenderer((TAst)ast);
}
