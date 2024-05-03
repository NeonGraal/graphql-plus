using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

public class MergeUnionMembersTests
  : TestGroups<UnionMemberAst>
{
  private readonly MergeUnionMembers _merger = new();

  internal override GroupsMerger<UnionMemberAst> MergerGroups => _merger;

  protected override UnionMemberAst MakeAst(string input)
    => new(AstNulls.At, input);
}
