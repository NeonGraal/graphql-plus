using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeCategories
  : DescribedMerger<CategoryDeclAst>
{
  public override bool CanMerge(CategoryDeclAst[] items)
    => items.Select(i => i.Output).Distinct().Count() == 1
     && items.CanMerge(item => item.Option)
    && base.CanMerge(items);
}
