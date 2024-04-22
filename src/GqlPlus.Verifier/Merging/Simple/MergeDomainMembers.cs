using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Merging.Simple;

internal class MergeDomainMembers(
  ILoggerFactory logger
) : AstDomainItemMerger<DomainMemberAst>(logger)
{
  protected override string ItemGroupKey(DomainMemberAst item)
    => item.Member;

  protected override string ItemMatchName => "Excludes~EnumType";
  protected override string ItemMatchKey(DomainMemberAst item)
    => $"{item.Excludes}~{item.EnumType}";
}
