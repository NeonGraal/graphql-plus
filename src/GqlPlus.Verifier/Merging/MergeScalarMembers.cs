using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarMembers
  : AstScalarItemMerger<ScalarMemberAst>
{
  protected override string ItemGroupKey(ScalarMemberAst item)
    => item.Member;

  protected override string ItemMatchKey(ScalarMemberAst item)
    => $"{item.Excludes}~{item.EnumType}";
}
