using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeCategories
  : NamedMerger<CategoryDeclAst>
{
  public override bool CanMerge(CategoryDeclAst[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Description)
      && items.CanMerge(item => item.Option);

  protected override string ItemMatchKey(CategoryDeclAst item)
    => $"{item.Output}-{item.Option}";

  protected override CategoryDeclAst MergeGroup(CategoryDeclAst[] items)
    => items.First() with { Description = items.MergeDescriptions() };
}
