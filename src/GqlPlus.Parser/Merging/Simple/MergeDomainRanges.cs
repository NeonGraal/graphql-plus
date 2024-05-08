using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRanges(
  ILoggerFactory logger
) : AstDomainItemMerger<IGqlpDomainRange>(logger)
{
  protected override string ItemMatchName => "Range";
  protected override string ItemGroupKey(IGqlpDomainRange item)
    => ((DomainRangeAst)item).GetFields().Skip(2).Joined();
}
