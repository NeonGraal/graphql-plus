using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

public class MergeUnionMembersTests
  : TestGroupsMerger<IGqlpUnionItem, string>
{
  private readonly MergeUnionMembers _merger = new();

  internal override GroupsMerger<IGqlpUnionItem> MergerGroups => _merger;

  protected override IGqlpUnionItem MakeAst(string input)
    => new UnionMemberAst(AstNulls.At, input, "");
}
