
namespace GqlPlus.Modelling.Objects;

internal class TypeParamModeller
  : ModellerBase<IAstTypeParam, TypeParamModel>
{
  protected override TypeParamModel ToModel(IAstTypeParam ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description, GetTypeRefModel(ast.Constraint, typeKinds));

  private TypeRefModel<TypeKindModel> GetTypeRefModel(string constraint, IMap<TypeKindModel> typeKinds)
    => typeKinds.TryGetValue(constraint, out TypeKindModel typeKind)
        ? new TypeRefModel<TypeKindModel>(typeKind, constraint, "")
        : throw new ModelTypeException<IAstTypeParam>($"Kind of {constraint} not found");
}
