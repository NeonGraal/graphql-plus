using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainTrueFalse(
  IMergerRepository mergers
) : AstDomainItemMerger<IAstDomainTrueFalse>(mergers)
{
  protected override string ItemGroupKey(IAstDomainTrueFalse item)
    => $"{item.IsTrue}";

  internal static MergeDomainTrueFalse Factory(IMergerRepository m) => new(m);
}
