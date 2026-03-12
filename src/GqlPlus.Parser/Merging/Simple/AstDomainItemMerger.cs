using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal abstract class AstDomainItemMerger<TItem>(
  IMergerRepository mergers
) : DistinctMerger<TItem>(mergers)
  where TItem : IGqlpDomainItem
{
  protected override string ItemMatchName => "Excludes";
  protected override string ItemMatchKey(TItem item)
    => item.Excludes.ToString();

  protected override TItem MergeGroup(IEnumerable<TItem> group)
    => group.First();
}
