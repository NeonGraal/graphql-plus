using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainRegexes(
  ILoggerFactory logger
) : AstDomainItemMerger<DomainRegexAst>(logger)
{
  protected override string ItemMatchName => "Regex";
  protected override string ItemGroupKey(DomainRegexAst item)
    => item.Regex;
}
