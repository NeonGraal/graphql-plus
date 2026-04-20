using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRegexes(
  IMergerRepository mergers
) : AstDomainItemMerger<IAstDomainRegex>(mergers)
{
  protected override string ItemGroupKey(IAstDomainRegex item)
    => item.Pattern;

  internal static MergeDomainRegexes Factory(IMergerRepository m) => new(m);
}
