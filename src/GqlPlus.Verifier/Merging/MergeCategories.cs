using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeCategories
  : DescribedMerger<CategoryDeclAst>
{
  public override bool CanMerge(CategoryDeclAst[] items)
    => base.CanMerge(items)
     && items.CanMerge(item => item.Option);

  protected override string ItemGroupKey(CategoryDeclAst item)
    => item.Output;
}
