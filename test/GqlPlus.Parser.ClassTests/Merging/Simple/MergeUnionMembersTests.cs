using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

public class MergeUnionMembersTests
  : TestGroups<IGqlpUnionItem>
{
  private readonly MergeUnionMembers _merger = new();

  internal override GroupsMerger<IGqlpUnionItem> MergerGroups => _merger;

  protected override UnionMemberAst MakeAst(string input)
    => new(AstNulls.At, input, "");
}
