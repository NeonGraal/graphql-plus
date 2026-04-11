namespace GqlPlus.Modelling.Globals;

internal class OperationModeller
  : ModellerBase<IAstSchemaOperation, OperationModel>
{
  protected override OperationModel ToModel(IAstSchemaOperation ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Category, new(), "") {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
    };
}
