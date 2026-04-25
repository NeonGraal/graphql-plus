using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling;

internal class TypesModeller(
  IModellerRepository modellers
) : ModellerBase<IAstType, BaseTypeModel>
  , ITypesModeller
{
  private readonly IModellerRepository _modellers = modellers;

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
    => _modellers.TypeModellers.Single(t => t.ForType(ast)).Kind;

  protected override BaseTypeModel ToModel(IAstType ast, IMap<TypeKindModel> typeKinds)
    => _modellers.TypeModellers.Single(t => t.ForType(ast)).ToTypeModel(ast, typeKinds);

  internal static TypesModeller Factory(IModellerRepository r) => new(r);
}

public interface ITypesModeller
  : IModeller<IAstType, BaseTypeModel>
{
  void AddTypeKinds(IEnumerable<IAstType> asts, IMap<TypeKindModel> typeKinds);
  TypeKindModel GetTypeKind(IAstType ast);
}
