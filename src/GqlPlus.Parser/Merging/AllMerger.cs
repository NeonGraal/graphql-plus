using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

internal abstract class AllMerger<TItem>(
  IMergerRepository mergers
) : DistinctMerger<TItem>(mergers)
  where TItem : IAstType
{
  private readonly Defer<IMergeAll<TItem>>.LA _all = mergers.AllMergersFor<TItem>();

  protected override IMessages CanMergeGroup(IGrouping<string, TItem> group)
  {
    IMessages result = base.CanMergeGroup(group);
    if (result.Any()) {
      return result;
    }

    List<(IMergeAll<TItem> domain, IMessages)> each = [.. _all.IA.Select(domain => (domain, domain.CanMerge(group)))];
    result.Add(each.SelectMany(item => item.Item2));
    return result;
  }

  protected override string ItemGroupKey(TItem item) => item.Name;

  protected override TItem MergeGroup(IEnumerable<TItem> group)
    => _all.IA.SelectMany(domain => domain.Merge(group)).First();
}
