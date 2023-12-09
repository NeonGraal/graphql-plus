using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class DescribedMerger<TItem> : DistinctMerger<TItem>
  where TItem : IAstDescribed
{
  public override bool CanMerge(TItem[] items)
    => base.CanMerge(items) && items.CanMerge(item => item.Description);
}
