using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging.Types;

public class MergeUnionMembersTests
  : TestGroups<UnionMemberAst>
{
  private readonly MergeUnionMembers _merger = new();

  internal override GroupsMerger<UnionMemberAst> MergerGroups => _merger;

  protected override UnionMemberAst MakeAst(string input)
    => new(AstNulls.At, input);
}
