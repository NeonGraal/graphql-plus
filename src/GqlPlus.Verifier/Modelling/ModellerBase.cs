using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract class ModellerBase<TAst, TModel>
  : IModeller<TAst>
  where TAst : AstBase
  where TModel : IRendering
{
  public T ToModel<T>(TAst? ast)
    => TryModel<T>(ast) ?? throw new ModelTypeException<T>(ast);

  public T[] ToModels<T>(IEnumerable<TAst>? asts)
    => [.. TryModels<T>(asts).Where(m => m is not null).Cast<T>()];

  public IRendering ToRenderer(TAst ast)
    => ToModel(ast);

  public T? TryModel<T>(TAst? ast)
    => ast is not null && typeof(T).IsAssignableFrom(typeof(TModel))
      ? (T)(object)ToModel(ast)
      : default;

  public IEnumerable<T?> TryModels<T>(IEnumerable<TAst>? asts)
    => asts?.Select(TryModel<T>) ?? [];

  internal abstract TModel ToModel(TAst ast);
}
