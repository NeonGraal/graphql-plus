using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling;

internal class TypesModeller(
  IEnumerable<ITypeModeller> types
) : ModellerBase<IAstType, BaseTypeModel>
  , ITypesModeller
{
  public void AddTypeKinds(IEnumerable<IAstType> asts, IMap<TypeKindModel> typeKinds)
  {
    foreach (IAstType ast in asts) {
      if (typeKinds.TryGetValue(ast.Name, out TypeKindModel kind)) {
        if (kind != GetTypeKind(ast)) {
          throw new ModelTypeException<IAstType>($"Type '{ast.Name}' has multiple kinds: {kind} and {GetTypeKind(ast)}.");
        }
      } else {
        typeKinds.Add(ast.Name, GetTypeKind(ast));
      }
    }
  }

  public TypeKindModel GetTypeKind(IAstType ast)
    => types.Single(t => t.ForType(ast)).Kind;

  protected override BaseTypeModel ToModel(IAstType ast, IMap<TypeKindModel> typeKinds)
    => types.Single(t => t.ForType(ast)).ToTypeModel(ast, typeKinds);
}

public interface ITypesModeller
  : IModeller<IAstType, BaseTypeModel>
{
  void AddTypeKinds(IEnumerable<IAstType> asts, IMap<TypeKindModel> typeKinds);
  TypeKindModel GetTypeKind(IAstType ast);
}
