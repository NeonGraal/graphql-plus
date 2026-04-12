namespace GqlPlus.Modelling.Globals;

// ResolutionModel => CategoryOption

internal class CategoryModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSchemaCategory, CategoryModel>
{
  private readonly IModeller<IAstModifier, ModifierModel> _modifier = modellers.ModellerFor<IAstModifier, ModifierModel>();

  protected override CategoryModel ToModel(IAstSchemaCategory ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Output.TypeRef(TypeKindModel.Output), ast.Description) {
      Aliases = [.. ast.Aliases],
      Resolution = ast.CategoryOption,
      Modifiers = _modifier.ToModels(ast.Modifiers, typeKinds),
    };
}
