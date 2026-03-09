using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainTrueFalse(
  IMergerRepository mergers
) : AstDomainItemMerger<IGqlpDomainTrueFalse>(mergers.LoggerFactory)
{
  protected override string ItemGroupKey(IGqlpDomainTrueFalse item)
    => $"{item.IsTrue}";
}
