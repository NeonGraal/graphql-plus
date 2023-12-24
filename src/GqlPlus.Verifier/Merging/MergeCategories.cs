using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeCategories
  : AliasedMerger<CategoryDeclAst>
{
  public override bool CanMerge(IEnumerable<CategoryDeclAst> items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Option);

  protected override string ItemMatchKey(CategoryDeclAst item)
    => $"{item.Output}-{item.Option}";
}
