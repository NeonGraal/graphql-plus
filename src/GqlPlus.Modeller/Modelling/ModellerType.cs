namespace GqlPlus.Modelling;

internal abstract class ModellerType<TAst, TParent, TModel>(
  TypeKindModel kind
) : ModellerBase<TAst, TModel>, ITypeModeller
  where TAst : IGqlpType<TParent>
  where TParent : IEquatable<TParent>
  where TModel : BaseTypeModel
{
  TypeKindModel ITypeModeller.Kind => kind;

  bool ITypeModeller.ForType(IGqlpType ast)
    => ast is TAst;

  BaseTypeModel ITypeModeller.ToTypeModel(IGqlpType ast, IMap<TypeKindModel> typeKinds)
    => ToModel((TAst)ast, typeKinds);
}

internal interface ITypeModeller
{
  bool ForType(IGqlpType ast);
  TypeKindModel Kind { get; }
  BaseTypeModel ToTypeModel(IGqlpType ast, IMap<TypeKindModel> typeKinds);
}
