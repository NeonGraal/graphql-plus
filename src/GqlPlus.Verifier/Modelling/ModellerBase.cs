using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract class ModellerBase<TAst, TModel> : IModeller<TAst>
  where TAst : AstBase
  where TModel : IRendering
{
  public T? ToModel<T>(TAst ast)
    => typeof(T).IsAssignableFrom(typeof(TModel))
      ? (T)(object)ToModel(ast)
      : default;

  public IRendering ToRenderer(TAst ast)
    => ToModel(ast);

  internal abstract TModel ToModel(TAst ast);
}
