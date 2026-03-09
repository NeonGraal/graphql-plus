using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainLabels(
  IMergerRepository mergers
) : AstDomainItemMerger<IGqlpDomainLabel>(mergers.LoggerFactory)
{
  protected override string ItemGroupKey(IGqlpDomainLabel item)
    => $"{item.EnumType}~{item.EnumItem}";
}
