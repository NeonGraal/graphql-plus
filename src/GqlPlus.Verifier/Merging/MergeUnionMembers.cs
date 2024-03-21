using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeUnionMembers
  : GroupsMerger<UnionMemberAst>
{
  protected override bool CanMergeGroup(IGrouping<string, UnionMemberAst> group)
    => true;
  protected override string ItemGroupKey(UnionMemberAst item)
    => item.Name;
  protected override UnionMemberAst MergeGroup(IEnumerable<UnionMemberAst> group)
    => group.First();
}
