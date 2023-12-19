using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeCategories
  : DescribedsMerger<CategoryDeclAst>
{
  public override bool CanMerge(CategoryDeclAst[] items)
    => base.CanMerge(items)
     && items.CanMerge(item => item.Option);

  public override CategoryDeclAst Merge(CategoryDeclAst[] items)
    => items.First() with { Description = MergeDescriptions(items) };

  protected override string ItemMatchKey(CategoryDeclAst item)
    => $"{item.Output}-{item.Option}";
}
