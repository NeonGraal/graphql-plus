using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDomainRegexes(
  ILoggerFactory logger
) : AstDomainItemMerger<DomainRegexAst>(logger)
{
  protected override string ItemMatchName => "Regex";
  protected override string ItemGroupKey(DomainRegexAst item)
    => item.Regex;
}
