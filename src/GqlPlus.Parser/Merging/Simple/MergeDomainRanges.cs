using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRanges(
  IMergerRepository mergers
) : AstDomainItemMerger<IAstDomainRange>(mergers)
{
  protected override string ItemGroupKey(IAstDomainRange item)
    => ((DomainRangeAst)item).AsString;
}
