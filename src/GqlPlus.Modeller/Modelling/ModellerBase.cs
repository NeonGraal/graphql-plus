﻿namespace GqlPlus.Modelling;

internal abstract class ModellerBase<TAst, TModel>
  : IModeller<TAst, TModel>
  where TAst : IGqlpError
  where TModel : IModelBase
{
  public T ToModel<T>(TAst? ast, IMap<TypeKindModel> typeKinds)
    => TryModel<T>(ast, typeKinds) ?? throw new ModelTypeException<T>(ast);
  public T[] ToModels<T>(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds)
    => [.. TryModels<T>(asts, typeKinds).Where(m => m is not null).Cast<T>()];
  T? IModeller<TAst>.TryModel<T>(TAst? ast, IMap<TypeKindModel> typeKinds)
    where T : default
    => TryModel<T>(ast, typeKinds);
  IEnumerable<T?> IModeller<TAst>.TryModels<T>(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds)
    where T : default
    => TryModels<T>(asts, typeKinds);

  TModel IModeller<TAst, TModel>.ToModel(TAst? ast, IMap<TypeKindModel> typeKinds)
    => ast is null ? throw new ModelTypeException<TAst>(ast)
    : ToModel(ast, typeKinds);
  TModel[] IModeller<TAst, TModel>.ToModels(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds)
    => ToModels<TModel>(asts, typeKinds);
  TModel? IModeller<TAst, TModel>.TryModel(TAst? ast, IMap<TypeKindModel> typeKinds)
    => TryModel<TModel>(ast, typeKinds);
  IEnumerable<TModel?> IModeller<TAst, TModel>.TryModels(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds)
    => TryModels<TModel>(asts, typeKinds);

  protected abstract TModel ToModel(TAst ast, IMap<TypeKindModel> typeKinds);

  protected virtual T? TryModel<T>(TAst? ast, IMap<TypeKindModel> typeKinds)
    => ast is not null && typeof(T).IsAssignableFrom(typeof(TModel))
      ? (T)(object)ToModel(ast, typeKinds)
      : default;

  protected virtual IEnumerable<T?> TryModels<T>(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds)
    => asts?.Select(a => TryModel<T>(a, typeKinds)) ?? [];
}
