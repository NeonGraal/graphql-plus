using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarMembersTests
  : TestScalarItems<ScalarMemberAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsFalse(string name)
    => CanMerge_False([
      MakeAst(name) with { Excludes = true },
      MakeAst(name)]);

  private readonly MergeScalarMembers _merger = new();

  internal override GroupsMerger<ScalarMemberAst> MergerGroups => _merger;

  protected override ScalarMemberAst MakeAst(string input)
    => new(AstNulls.At, false, input);
}
