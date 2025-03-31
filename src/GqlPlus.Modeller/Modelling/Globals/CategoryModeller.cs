namespace GqlPlus.Modelling.Globals;

// ResolutionModel => CategoryOption

internal class CategoryModeller(
  IModeller<IGqlpModifier, ModifierModel> modifier
) : ModellerBase<IGqlpSchemaCategory, CategoryModel>
{
  protected override CategoryModel ToModel(IGqlpSchemaCategory ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Output.TypeRef(TypeKindModel.Output), ast.Description) {
      Aliases = [.. ast.Aliases],
      Resolution = ast.CategoryOption,
      Modifiers = modifier.ToModels(ast.Modifiers, typeKinds),
    };
}
