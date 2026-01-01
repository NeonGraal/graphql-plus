using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainLabels(
  ILoggerFactory logger
) : AstDomainItemMerger<IGqlpDomainLabel>(logger)
{
  protected override string ItemGroupKey(IGqlpDomainLabel item)
    => $"{item.EnumType}~{item.EnumItem}";
}
