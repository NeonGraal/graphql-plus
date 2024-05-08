using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainTrueFalse(
  ILoggerFactory logger
) : AstDomainItemMerger<IGqlpDomainTrueFalse>(logger)
{
  protected override string ItemMatchName => "Value";
  protected override string ItemGroupKey(IGqlpDomainTrueFalse item)
    => $"{item.IsTrue}";
}
