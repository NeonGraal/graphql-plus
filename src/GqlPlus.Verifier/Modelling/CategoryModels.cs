using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// Todo : CatagoriesModel

public record class CategoryModel(
  string Name, TypeRefModel<TypeKindModel> Output
) : AliasedModel(Name)
{
  public CategoryOption Resolution { get; set; } = CategoryOption.Parallel;
  public ModifierModel[] Modifiers { get; set; } = [];

  internal override RenderStructure Render()
    => base.Render()
      .Add("resolution", Resolution, "_Resolution")
      .Add("output", Output.Render())
      .Add("modifiers", Modifiers.Render(true));
}

// ResolutionModel => CategoryOption

internal class CategoryModeller(
  IModeller<ModifierAst, ModifierModel> modifier
) : ModellerBase<CategoryDeclAst, CategoryModel>
{
  internal override CategoryModel ToModel(CategoryDeclAst ast)
    => new(ast.Name, ast.Output.TypeRef(TypeKindModel.Output)) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Resolution = ast.Option,
      Modifiers = modifier.ToModels(ast.Modifiers),
    };
}
