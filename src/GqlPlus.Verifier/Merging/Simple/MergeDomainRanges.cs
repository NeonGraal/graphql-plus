using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Merging.Simple;

internal class MergeDomainRanges(
  ILoggerFactory logger
) : AstDomainItemMerger<DomainRangeAst>(logger)
{
  protected override string ItemMatchName => "Range";
  protected override string ItemGroupKey(DomainRangeAst item)
    => item.GetFields().Skip(2).Joined();
}
