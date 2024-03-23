using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeUnionMembers
  : GroupsMerger<UnionMemberAst>
{
  protected override bool CanMergeGroup(IGrouping<string, UnionMemberAst> group)
    => group.Distinct().Count() == 1;
  protected override string ItemGroupKey(UnionMemberAst item)
    => item.Name;
  protected override UnionMemberAst MergeGroup(IEnumerable<UnionMemberAst> group)
    => group.First();
}
