using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarMembers(
  ILoggerFactory logger
) : AstScalarItemMerger<ScalarMemberAst>(logger)
{
  protected override string ItemGroupKey(ScalarMemberAst item)
    => item.Member;

  protected override string ItemMatchName => "Excludes~EnumType";
  protected override string ItemMatchKey(ScalarMemberAst item)
    => $"{item.Excludes}~{item.EnumType}";
}
