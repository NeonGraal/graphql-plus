
namespace GqlPlus.Modelling.Objects;

internal class TypeParamModeller
  : ModellerBase<IGqlpTypeParam, TypeParamModel>
{
  protected override TypeParamModel ToModel(IGqlpTypeParam ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description, GetTypeRefModel(ast.Constraint, typeKinds));

  private TypeRefModel<TypeKindModel> GetTypeRefModel(string constraint, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(constraint, out TypeKindModel typeKind)
        ? new TypeRefModel<TypeKindModel>(typeKind, constraint, "")
        : throw new ModelTypeException<IGqlpTypeParam>($"Kind of {constraint} not found");
}
