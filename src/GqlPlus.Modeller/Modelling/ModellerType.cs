using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling;

internal abstract class ModellerType<TAst, TParent, TModel>(
  TypeKindModel kind
) : ModellerBase<TAst, TModel>, ITypeModeller
  where TAst : IAstType<TParent>
  where TParent : IAstDescribed, IEquatable<TParent>
  where TModel : BaseTypeModel
{
  TypeKindModel ITypeModeller.Kind => kind;

  bool ITypeModeller.ForType(IAstType ast)
    => ast is TAst;

  BaseTypeModel ITypeModeller.ToTypeModel(IAstType ast, IMap<TypeKindModel> typeKinds)
    => ToModel((TAst)ast, typeKinds);
}

internal interface ITypeModeller
{
  bool ForType(IAstType ast);
  TypeKindModel Kind { get; }
  BaseTypeModel ToTypeModel(IAstType ast, IMap<TypeKindModel> typeKinds);
}
