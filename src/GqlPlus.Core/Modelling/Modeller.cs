using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Modelling;

public class Modeller<TAst, TModel>(
  Modeller<TAst, TModel>.D factory
) : DeferOne<IModeller<TAst, TModel>>(factory)
  , IModeller<TAst, TModel>
  where TAst : class
  where TModel : class
{
  public TModel? TryModel(TAst? ast, IMap<GqlpTypeKind> typeKinds) => I.TryModel(ast, typeKinds);
  public TModel ToModel(TAst? ast, IMap<GqlpTypeKind> typeKinds) => I.ToModel(ast, typeKinds);
  [ExcludeFromCodeCoverage]
  public IEnumerable<TModel?> TryModels(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds) => I.TryModels(asts, typeKinds);
  public TModel[] ToModels(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds) => I.ToModels(asts, typeKinds);
  public T ToModel<T>(TAst? ast, IMap<GqlpTypeKind> typeKinds) => I.ToModel<T>(ast, typeKinds);
  [ExcludeFromCodeCoverage]
  public T[] ToModels<T>(IEnumerable<TAst>? asts, IMap<GqlpTypeKind> typeKinds) => I.ToModels<T>(asts, typeKinds);

  public static implicit operator Modeller<TAst, TModel>(D factory)
    => new(factory.ThrowIfNull());
}
