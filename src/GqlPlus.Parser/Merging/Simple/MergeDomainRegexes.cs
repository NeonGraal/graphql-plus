using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRegexes(
  IMergerRepository mergers
) : AstDomainItemMerger<IGqlpDomainRegex>(mergers)
{
  protected override string ItemGroupKey(IGqlpDomainRegex item)
    => item.Pattern;
}
