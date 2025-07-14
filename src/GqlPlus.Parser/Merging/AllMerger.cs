using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

internal abstract class AllMerger<TItem>(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<TItem>> all
) : DistinctMerger<TItem>(logger)
  where TItem : IGqlpType
{
  protected override IMessages CanMergeGroup(IGrouping<string, TItem> group)
  {
    IMessages result = base.CanMergeGroup(group);
    if (!result.Any()) {
      List<(IMergeAll<TItem> domain, IMessages)> each = [.. all.Select(domain => (domain, domain.CanMerge(group)))];
      result.Add(each.SelectMany(item => item.Item2));
    }

    return result;
  }

  protected override string ItemGroupKey(TItem item) => item.Name;

  protected override TItem MergeGroup(IEnumerable<TItem> group)
    => all.SelectMany(domain => domain.Merge(group)).First();
}
