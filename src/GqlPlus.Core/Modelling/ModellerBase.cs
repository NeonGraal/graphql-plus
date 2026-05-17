namespace GqlPlus.Modelling;

public abstract class ModellerBase<TAst, TModel>
  : IModeller<TAst, TModel>
  where TAst : class
  where TModel : class
{
  public T ToModel<T>(TAst? ast, IMap<GqlpTypeKind> typeKinds)
    => TryModel<T>(ast, typeKinds)
      ?? throw new InvalidOperationException(
        $"Type '{ast?.GetType().TidyTypeName() ?? "null"}' Model is not '{typeof(T).TidyTypeName()}'");

  public T[] ToModels<T>(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds)
    => [.. TryModels<T>(asts, typeKinds).Where(m => m is not null).Cast<T>()];

  TModel IModeller<TAst, TModel>.ToModel(TAst? ast, IMap<GqlpTypeKind> typeKinds)
    => ast is null
      ? throw new InvalidOperationException($"Type '{typeof(TAst).TidyTypeName()}' ast is null")
      : ToModel(ast, typeKinds);

  TModel[] IModeller<TAst, TModel>.ToModels(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds)
    => ToModels<TModel>(asts, typeKinds);

  TModel? IModeller<TAst, TModel>.TryModel(TAst? ast, IMap<GqlpTypeKind> typeKinds)
    => TryModel<TModel>(ast, typeKinds);

  IEnumerable<TModel?> IModeller<TAst, TModel>.TryModels(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds)
    => TryModels<TModel>(asts, typeKinds);

  protected abstract TModel ToModel(TAst ast, IMap<GqlpTypeKind> typeKinds);

  protected virtual T? TryModel<T>(TAst? ast, IMap<GqlpTypeKind> typeKinds)
    => ast is not null && typeof(T).IsAssignableFrom(typeof(TModel))
      ? (T)(object)ToModel(ast, typeKinds)
      : default;

  protected virtual IEnumerable<T?> TryModels<T>(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds)
    => asts?.Select(a => TryModel<T>(a, typeKinds)) ?? [];
}
