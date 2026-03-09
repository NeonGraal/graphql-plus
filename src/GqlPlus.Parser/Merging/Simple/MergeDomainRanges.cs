using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRanges(
  IMergerRepository mergers
) : AstDomainItemMerger<IGqlpDomainRange>(mergers.LoggerFactory)
{
  protected override string ItemGroupKey(IGqlpDomainRange item)
    => ((DomainRangeAst)item).AsString;
}
