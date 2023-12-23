namespace GqlPlus.Verifier.Merging;

public abstract class GroupsMerger<TItem>
  : BaseMerger<TItem>
{
  protected abstract string ItemGroupKey(TItem item);
  protected abstract TItem MergeGroup(TItem[] group);

  protected virtual bool CanMergeGroup(IGrouping<string, TItem> group)
      => group.Distinct().Count() == 1;

  public override bool CanMerge(TItem[] items)
    => base.CanMerge(items) && items.GroupBy(ItemGroupKey).All(CanMergeGroup);

  public override TItem[] Merge(TItem[] items)
    => items?.GroupMerger(ItemGroupKey, MergeGroup) ?? [];
}

internal record struct Indexed<TItem>(TItem Item, int Index)
{
  public static Indexed<TItem> To(TItem item, int n)
    => new(item, n);

  internal readonly Indexed<TResult> Select<TResult>(Func<TItem, TResult> selector)
    where TResult : IComparable<TResult>
    => new(selector(Item), Index);
}
