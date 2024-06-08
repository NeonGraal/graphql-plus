namespace GqlPlus.Modelling.Globals;

// ResolutionModel => CategoryOption

internal class CategoryModeller(
  IModeller<IGqlpModifier, ModifierModel> modifier
) : ModellerBase<IGqlpSchemaCategory, CategoryModel>
{
  protected override CategoryModel ToModel(IGqlpSchemaCategory ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Output.TypeRef(TypeKindModel.Output)) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Resolution = ast.CategoryOption,
      Modifiers = modifier.ToModels(ast.Modifiers, typeKinds),
    };
}
