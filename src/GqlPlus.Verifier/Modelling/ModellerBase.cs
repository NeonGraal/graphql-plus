using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal abstract class ModellerBase<TAst, TModel>
  : IModeller<TAst, TModel>
  where TAst : AstBase
  where TModel : IRendering
{
  public IRendering ToRenderer(TAst ast)
    => ToModel(ast);

  public T ToModel<T>(TAst? ast)
    => TryModel<T>(ast) ?? throw new ModelTypeException<T>(ast);
  public T[] ToModels<T>(IEnumerable<TAst>? asts)
    => [.. TryModels<T>(asts).Where(m => m is not null).Cast<T>()];
  T? IModeller<TAst>.TryModel<T>(TAst? ast)
    where T : default
    => TryModel<T>(ast);
  IEnumerable<T?> IModeller<TAst>.TryModels<T>(IEnumerable<TAst>? asts)
    where T : default
    => TryModels<T>(asts);

  TModel IModeller<TAst, TModel>.ToModel(TAst? ast)
    => ToModel<TModel>(ast);
  TModel[] IModeller<TAst, TModel>.ToModels(IEnumerable<TAst>? asts)
    => ToModels<TModel>(asts);
  TModel? IModeller<TAst, TModel>.TryModel(TAst? ast)
    => TryModel<TModel>(ast);
  IEnumerable<TModel?> IModeller<TAst, TModel>.TryModels(IEnumerable<TAst>? asts)
    => TryModels<TModel>(asts);

  internal abstract TModel ToModel(TAst ast);

  protected virtual T? TryModel<T>(TAst? ast)
    => ast is not null && typeof(T).IsAssignableFrom(typeof(TModel))
      ? (T)(object)ToModel(ast)
      : default;

  protected IEnumerable<T?> TryModels<T>(IEnumerable<TAst>? asts)
    => asts?.Select(TryModel<T>) ?? [];
}
