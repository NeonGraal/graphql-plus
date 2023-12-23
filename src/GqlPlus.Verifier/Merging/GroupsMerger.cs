
namespace GqlPlus.Verifier.Merging;

public abstract class GroupsMerger<TItem>
  : BaseMerger<TItem>
{
  protected abstract string ItemGroupKey(TItem item);
  protected abstract TItem MergeGroup(IEnumerable<TItem> group);

  protected abstract bool CanMergeGroup(IGrouping<string, TItem> group);

  public override bool CanMerge(TItem[] items)
    => base.CanMerge(items) && items.GroupBy(ItemGroupKey).All(CanMergeGroup);

  public override TItem[] Merge(TItem[] items)
    => items?.GroupMerger(ItemGroupKey, MergeGroup) ?? [];
}
