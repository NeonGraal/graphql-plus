using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainRangesTests(
  ITestOutputHelper outputHelper
) : TestAbbreviated<DomainRangeAst, DomainRangeInput>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameExcludes_ReturnsGood(DomainRangeInput input)
    => CanMerge_Good([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(DomainRangeInput input)
    => CanMerge_Errors([MakeAst(input) with { Excludes = true }, MakeAst(input)]);

  private readonly MergeDomainRanges _merger = new(outputHelper.ToLoggerFactory());

  protected override IMerge<DomainRangeAst> MergerBase => _merger;

  protected override DomainRangeAst MakeAst(DomainRangeInput input)
    => new(AstNulls.At, false, input.Lower, input.Upper);
}
