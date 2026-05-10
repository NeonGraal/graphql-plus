namespace GqlPlus.Modelling.Globals;

// ResolutionModel => CategoryOption

internal class CategoryModeller(
  IModellerRepository modellers
) : ModellerBase<IAstSchemaCategory, CategoryModel>
{
  private readonly DeferOne<IModeller<IAstModifier, ModifierModel>> _modifier = modellers.ModellerFor<IAstModifier, ModifierModel>();

  protected override CategoryModel ToModel(IAstSchemaCategory ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Output.TypeRef(TypeKindModel.Output), ast.Description) {
      Aliases = [.. ast.Aliases],
      Resolution = (CategoryOptionModel)ast.CategoryOption,
      Modifiers = _modifier.I.ToModels(ast.Modifiers, typeKinds),
    };

  internal static CategoryModeller Factory(IModellerRepository r) => new(r);
}
