namespace GqlPlus.Modelling;

public interface IModeller<TAst>
  where TAst : IAstError
{
  /*
  T? TryModel<T>(TAst? ast, IMap<TypeKindModel> typeKinds);
  IEnumerable<T?> TryModels<T>(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds);
  */
  T ToModel<T>(TAst? ast, IMap<TypeKindModel> typeKinds);
  T[] ToModels<T>(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds);
}

public interface IModeller<TAst, TModel>
  : IModeller<TAst>
  where TAst : IAstError
  where TModel : IModelBase
{
  TModel? TryModel(TAst? ast, IMap<TypeKindModel> typeKinds);
  TModel ToModel(TAst? ast, IMap<TypeKindModel> typeKinds);
  IEnumerable<TModel?> TryModels(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds);
  TModel[] ToModels(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds);
}

public class Modeller<TAst, TModel>(
  Modeller<TAst, TModel>.D factory
) : DeferOne<IModeller<TAst, TModel>>(factory)
  , IModeller<TAst, TModel>
  where TAst : IAstError
  where TModel : IModelBase
{
  public TModel? TryModel(TAst? ast, IMap<TypeKindModel> typeKinds) => I.TryModel(ast, typeKinds);
  public TModel ToModel(TAst? ast, IMap<TypeKindModel> typeKinds) => I.ToModel(ast, typeKinds);
  public IEnumerable<TModel?> TryModels(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds) => I.TryModels(asts, typeKinds);
  public TModel[] ToModels(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds) => I.ToModels(asts, typeKinds);
  public T ToModel<T>(TAst? ast, IMap<TypeKindModel> typeKinds) => I.ToModel<T>(ast, typeKinds);
  public T[] ToModels<T>(IEnumerable<TAst>? asts, IMap<TypeKindModel> typeKinds) => I.ToModels<T>(asts, typeKinds);

  public static implicit operator Modeller<TAst, TModel>(D factory)
    => new(factory.ThrowIfNull());
}
