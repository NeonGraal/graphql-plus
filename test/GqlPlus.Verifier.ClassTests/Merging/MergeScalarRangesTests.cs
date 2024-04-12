using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRangesTests(
  ITestOutputHelper outputHelper
) : TestAbbreviated<ScalarRangeAst, ScalarRangeInput>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameExcludes_ReturnsGood(ScalarRangeInput input)
    => CanMerge_Good([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(ScalarRangeInput input)
    => CanMerge_Errors([MakeAst(input) with { Excludes = true }, MakeAst(input)]);

  private readonly MergeScalarRanges _merger = new(outputHelper.ToLoggerFactory());

  protected override IMerge<ScalarRangeAst> MergerBase => _merger;

  protected override ScalarRangeAst MakeAst(ScalarRangeInput input)
    => new(AstNulls.At, false, input.Lower, input.Upper);
}
