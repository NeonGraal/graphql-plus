namespace GqlPlus.Verifier.Merging;

internal abstract class DistinctMerger<TItem>
  : GroupsMerger<TItem>
{
  protected override bool CanMergeGroup(IGrouping<string, TItem> group)
    => group.Select(ItemMatchKey).Distinct().Count() == 1;

  protected abstract string ItemMatchKey(TItem item);
}
