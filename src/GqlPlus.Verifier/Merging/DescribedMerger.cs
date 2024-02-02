using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

internal abstract class DescribedMerger<TItem>
  : DistinctMerger<TItem>
  where TItem : IAstDescribed
{
  protected override bool CanMergeGroup(IGrouping<string, TItem> group)
    => base.CanMergeGroup(group)
    && group.CanMerge(item => item.Description);
}
