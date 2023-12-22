namespace GqlPlus.Verifier.Merging;

public abstract class GroupsMerger<TItem>
  : BaseMerger<TItem>
{
  protected abstract string ItemGroupKey(TItem item);
  protected abstract TItem MergeGroup(TItem[] items);

  protected virtual bool CanMergeGroup(IGrouping<string, TItem> group)
      => group.Distinct().Count() == 1;

  public override bool CanMerge(TItem[] items)
    => base.CanMerge(items) && items.GroupBy(ItemGroupKey).All(CanMergeGroup);

  public override TItem[] Merge(TItem[] items)
  {
    base.Merge(items);

    List<Indexed<TItem>> result = [];
    var groups = items.Select(ToIndex).GroupBy(i => ItemGroupKey(i.Item));

    foreach (var group in groups) {
      var item = MergeGroup([.. group.Select(i => i.Item)]);
      result.Add(new(item, group.Min(i => i.Index)));
    }

    return [.. result.OrderBy(i => i.Index).Select(i => i.Item)];
  }

  internal Indexed<TItem> ToIndex(TItem item, int n)
    => new(item, n);
}

internal record struct Indexed<TItem>(TItem Item, int Index)
{
  internal readonly Indexed<TResult> Select<TResult>(Func<TItem, TResult> selector)
    where TResult : IComparable<TResult>
    => new(selector(Item), Index);
}
