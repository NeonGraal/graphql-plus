using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeUnionMembersTests
  : TestGroupsMerger<IAstUnionMember, string>
{
  private readonly MergeUnionMembers _merger = new();

  internal override GroupsMerger<IAstUnionMember> MergerGroups => _merger;

  protected override IAstUnionMember MakeAst(string input)
    => new UnionMemberAst(AstNulls.At, input, "");
}
