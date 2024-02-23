using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract class ModellerType<TAst, TParent, TModel>
  : ModellerBase<TAst, TModel>, IModeller<AstType<TParent>>
  where TAst : AstType<TParent>
  where TParent : IEquatable<TParent>
  where TModel : IRendering
{
  T? IModeller<AstType<TParent>>.ToModel<T>(AstType<TParent>? ast)
    where T : default
    => ToModel<T>((TAst?)ast);

  IRendering IModeller<AstType<TParent>>.ToRenderer(AstType<TParent> ast)
    => ToRenderer((TAst)ast);
}
