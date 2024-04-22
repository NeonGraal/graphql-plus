using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Merging.Simple;

internal class MergeDomainRegexes(
  ILoggerFactory logger
) : AstDomainItemMerger<DomainRegexAst>(logger)
{
  protected override string ItemMatchName => "Regex";
  protected override string ItemGroupKey(DomainRegexAst item)
    => item.Regex;
}
