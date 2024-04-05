using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRegexesTests(
  ITestOutputHelper outputHelper
) : TestScalarItems<ScalarRegexAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsFalse(string name)
    => CanMerge_False([MakeAst(name) with { Excludes = true }, MakeAst(name)]);

  private readonly MergeScalarRegexes _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<ScalarRegexAst> MergerGroups => _merger;

  protected override ScalarRegexAst MakeAst(string input)
    => new(AstNulls.At, false, input);
}
