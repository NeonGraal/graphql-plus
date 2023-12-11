using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class DescribedsMerger<TItem>
  : DistinctsMerger<TItem>
  where TItem : IAstDescribed
{
  public override bool CanMerge(TItem[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Description);
}
