using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarMembers
  : DistinctMerger<ScalarMemberAst>
{
  protected override string ItemGroupKey(ScalarMemberAst item) => item.Member;

  protected override string ItemMatchKey(ScalarMemberAst item)
    => $"{item.Excludes}-{item.EnumType}";

  protected override ScalarMemberAst MergeGroup(IEnumerable<ScalarMemberAst> group)
    => group.First();
}
