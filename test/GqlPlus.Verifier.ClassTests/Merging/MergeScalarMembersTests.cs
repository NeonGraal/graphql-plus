using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarMembersTests
  : TestGroups<ScalarMemberAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameExcludes_ReturnsTrue(string name)
    => CanMerge_True([
      new ScalarMemberAst(AstNulls.At, false, name),
      new ScalarMemberAst(AstNulls.At, false, name)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentExcludes_ReturnsFalse(string name)
    => CanMerge_False([
      new ScalarMemberAst(AstNulls.At, true, name),
      new ScalarMemberAst(AstNulls.At, false, name)]);

  private readonly MergeScalarMembers _merger = new();

  protected override GroupsMerger<ScalarMemberAst> MergerGroups => _merger;

  protected override ScalarMemberAst MakeDistinct(string name)
    => new(AstNulls.At, false, name);
}
