using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarMembersTests
  : TestGroups<ScalarMemberAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameExcludes_ReturnsTrue(string name)
    => CanMerge_True([
      new ScalarMemberAst(AstNulls.At, false, name),
      new ScalarMemberAst(AstNulls.At, false, name)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsFalse(string name)
    => CanMerge_False([
      new ScalarMemberAst(AstNulls.At, true, name),
      new ScalarMemberAst(AstNulls.At, false, name)]);

  private readonly MergeScalarMembers _merger = new();

  internal override GroupsMerger<ScalarMemberAst> MergerGroups => _merger;

  protected override ScalarMemberAst MakeDistinct(string name)
    => new(AstNulls.At, false, name);
}
