namespace GqlPlus.Modelling;

internal class TypesModeller(
  IEnumerable<ITypeModeller> types
) : ModellerBase<IGqlpType, BaseTypeModel>
  , ITypesModeller
{
  public void AddTypeKinds(IEnumerable<IGqlpType> asts, IMap<TypeKindModel> typeKinds)
  {
    foreach (IGqlpType ast in asts) {
      if (typeKinds.TryGetValue(ast.Name, out TypeKindModel kind)) {
        if (kind != GetTypeKind(ast)) {
          throw new ModelTypeException<IGqlpType>($"Type '{ast.Name}' has multiple kinds: {kind} and {GetTypeKind(ast)}.");
        }
      } else {
        typeKinds.Add(ast.Name, GetTypeKind(ast));
      }
    }
  }

  public TypeKindModel GetTypeKind(IGqlpType ast)
    => types.Single(t => t.ForType(ast)).Kind;

  protected override BaseTypeModel ToModel(IGqlpType ast, IMap<TypeKindModel> typeKinds)
    => types.Single(t => t.ForType(ast)).ToTypeModel(ast, typeKinds);
}

public interface ITypesModeller
  : IModeller<IGqlpType, BaseTypeModel>
{
  void AddTypeKinds(IEnumerable<IGqlpType> asts, IMap<TypeKindModel> typeKinds);
  TypeKindModel GetTypeKind(IGqlpType ast);
}
