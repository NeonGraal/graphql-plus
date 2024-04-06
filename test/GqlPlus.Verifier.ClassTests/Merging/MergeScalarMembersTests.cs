using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarMembersTests(
  ITestOutputHelper outputHelper
) : TestScalarItems<ScalarMemberAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsFalse(string name)
    => CanMerge_False([
      MakeAst(name) with { Excludes = true },
      MakeAst(name)]);

  private readonly MergeScalarMembers _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<ScalarMemberAst> MergerGroups => _merger;

  protected override ScalarMemberAst MakeAst(string input)
    => new(AstNulls.At, false, input);
}
