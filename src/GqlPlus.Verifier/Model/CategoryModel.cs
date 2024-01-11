using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal record class CategoryModel(string Name, string Output)
  : ModelAliased(Name)
{
  public CategoryOption Resolution { get; set; } = CategoryOption.Parallel;
  public ModifierModel[] Modifiers { get; set; } = [];

  protected override string Tag => "Category";

  public override RenderValue Render()
    => base.Render()
      .Add("resolution", new("_Resolution", Resolution.ToString()))
      .Add("output", new("", Output))
      .Add("modifiers", new("", Modifiers.Render(), true));
}

internal static class CategoryHelper
{
  internal static CategoryModel ToModel(this CategoryDeclAst category)
    => new(category.Name, category.Output) {
      Aliases = category.Aliases,
      Description = category.Description,
      Resolution = category.Option,
      Modifiers = [.. category.Modifiers.Select(m => m.ToModel())]
    };
}
