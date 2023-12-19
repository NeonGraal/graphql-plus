using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllTypes : DistinctsMerger<AstType>
{
  public override bool CanMerge(AstType[] items)
    => items.Select(i => i.GetType()).Distinct().Count() == 1;

  public override AstType Merge(AstType[] items)
    => items.First();

  protected override string ItemMatchKey(AstType item)
    => throw new InvalidOperationException();


}
