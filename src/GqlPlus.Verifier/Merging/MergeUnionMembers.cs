﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeUnionMembers
  : GroupsMerger<UnionMemberAst>
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, UnionMemberAst> group)
    => group.Distinct().Count() == 1 ? []
    : new TokenMessages(group.Last().Error("Union Members not unique for " + group.Key));
  protected override string ItemGroupKey(UnionMemberAst item)
    => item.Name;
  protected override UnionMemberAst MergeGroup(IEnumerable<UnionMemberAst> group)
    => group.First();
}
