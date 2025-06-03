
namespace GqlPlus.Modelling.Objects;

internal class TypeParamModeller
  : ModellerBase<IGqlpTypeParam, TypeParamModel>
{
  protected override TypeParamModel ToModel(IGqlpTypeParam ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Description) {
      Constraint = typeKinds.TryGetValue(ast.Constraint, out TypeKindModel typeKind)
        ? new TypeRefModel<TypeKindModel>(typeKind, ast.Constraint, "")
        : null,
    };
}
