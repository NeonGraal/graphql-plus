using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRegexes(
  IMergerRepository mergers
) : AstDomainItemMerger<IGqlpDomainRegex>(mergers.LoggerFactory)
{
  protected override string ItemGroupKey(IGqlpDomainRegex item)
    => item.Pattern;
}
