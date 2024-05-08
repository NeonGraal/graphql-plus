using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainMembers(
  ILoggerFactory logger
) : AstDomainItemMerger<IGqlpDomainMember>(logger)
{
  protected override string ItemGroupKey(IGqlpDomainMember item)
    => item.EnumItem;

  protected override string ItemMatchName => "Excludes~EnumType";
  protected override string ItemMatchKey(IGqlpDomainMember item)
    => $"{item.Excludes}~{item.EnumType}";
}
