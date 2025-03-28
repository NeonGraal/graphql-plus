using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainLabels(
  ILoggerFactory logger
) : AstDomainItemMerger<IGqlpDomainLabel>(logger)
{
  protected override string ItemGroupKey(IGqlpDomainLabel item)
    => item.EnumItem;

  protected override string ItemMatchName => "Excludes~EnumType";
  protected override string ItemMatchKey(IGqlpDomainLabel item)
    => $"{item.Excludes}~{item.EnumType}";
}
