using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRangesTests(
  ITestOutputHelper outputHelper
) : TestAbbreviated<ScalarRangeAst, ScalarRangeInput>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameExcludes_ReturnsTrue(ScalarRangeInput input)
    => CanMerge_True([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsFalse(ScalarRangeInput input)
    => CanMerge_False([MakeAst(input) with { Excludes = true }, MakeAst(input)]);

  private readonly MergeScalarRanges _merger = new(outputHelper.ToLoggerFactory());

  protected override IMerge<ScalarRangeAst> MergerBase => _merger;

  protected override ScalarRangeAst MakeAst(ScalarRangeInput input)
    => new(AstNulls.At, false, input.Lower, input.Upper);
}
