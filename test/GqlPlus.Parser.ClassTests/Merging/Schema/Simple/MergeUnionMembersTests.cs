using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeUnionMembersTests
  : TestGroupsMerger<IGqlpUnionMember, string>
{
  private readonly MergeUnionMembers _merger = new();

  internal override GroupsMerger<IGqlpUnionMember> MergerGroups => _merger;

  protected override IGqlpUnionMember MakeAst(string input)
    => new UnionMemberAst(AstNulls.At, input, "");
}
