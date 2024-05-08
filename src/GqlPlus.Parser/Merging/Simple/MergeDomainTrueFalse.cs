using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainTrueFalse(
  ILoggerFactory logger
) : AstDomainItemMerger<DomainTrueFalseAst>(logger)
{
  protected override string ItemMatchName => "Value";
  protected override string ItemGroupKey(DomainTrueFalseAst item)
    => $"{item.Value}";
}
