namespace GqlPlus.Modelling.Globals;

internal class OperationModeller
  : ModellerBase<IGqlpSchemaOperation, OperationModel>
{
  protected override OperationModel ToModel(IGqlpSchemaOperation ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Category, "TBC", "") {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
    };
}
