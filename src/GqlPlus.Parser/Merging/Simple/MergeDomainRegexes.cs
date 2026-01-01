using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRegexes(
  ILoggerFactory logger
) : AstDomainItemMerger<IGqlpDomainRegex>(logger)
{
  protected override string ItemGroupKey(IGqlpDomainRegex item)
    => item.Pattern;
}
