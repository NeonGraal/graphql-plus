using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal abstract class AstDomainItemMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : IGqlpDomainItem
{
  protected override string ItemMatchKey(TItem item)
    => item.Excludes.ToString();

  protected override TItem MergeGroup(IEnumerable<TItem> group)
    => group.First();
}
