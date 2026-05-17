namespace GqlPlus.Modelling;

public interface IModeller<TAst>
  where TAst : class
{
  T ToModel<T>(TAst? ast, IMap<GqlpTypeKind> typeKinds);
  T[] ToModels<T>(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds);
}

public interface IModeller<TAst, TModel>
  : IModeller<TAst>
  where TAst : class
  where TModel : class
{
  TModel? TryModel(TAst? ast, IMap<GqlpTypeKind> typeKinds);
  TModel ToModel(TAst? ast, IMap<GqlpTypeKind> typeKinds);
  IEnumerable<TModel?> TryModels(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds);
  TModel[] ToModels(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds);
}
