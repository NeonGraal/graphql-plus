using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainLabels(
  IMergerRepository mergers
) : AstDomainItemMerger<IAstDomainLabel>(mergers)
{
  protected override string ItemGroupKey(IAstDomainLabel item)
    => $"{item.EnumType}~{item.EnumItem}";

  internal static MergeDomainLabels Factory(IMergerRepository m) => new(m);
}
