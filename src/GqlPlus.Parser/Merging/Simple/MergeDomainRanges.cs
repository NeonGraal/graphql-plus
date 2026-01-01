using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRanges(
  ILoggerFactory logger
) : AstDomainItemMerger<IGqlpDomainRange>(logger)
{
  protected override string ItemGroupKey(IGqlpDomainRange item)
    => ((DomainRangeAst)item).AsString;
}
