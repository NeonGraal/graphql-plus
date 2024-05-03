
using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Merging;

internal abstract class GroupsMerger<TItem>
  : BaseMerger<TItem>
  where TItem : AstBase
{
  protected abstract string ItemGroupKey(TItem item);
  protected abstract ITokenMessages CanMergeGroup(IGrouping<string, TItem> group);
  protected abstract TItem MergeGroup(IEnumerable<TItem> group);

  public override ITokenMessages CanMerge(IEnumerable<TItem> items)
    => base.CanMerge(items).Add(items.GroupBy(ItemGroupKey).SelectMany(CanMergeGroup));

  public override IEnumerable<TItem> Merge(IEnumerable<TItem> items)
    => items?.GroupMerger(ItemGroupKey, MergeGroup) ?? [];
}
