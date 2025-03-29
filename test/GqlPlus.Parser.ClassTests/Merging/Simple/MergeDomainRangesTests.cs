using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Schema.Simple;

namespace GqlPlus.Merging.Simple;

public class MergeDomainRangesTests(
  ITestOutputHelper outputHelper
) : TestDomainItems<IGqlpDomainRange, DomainRangeInput>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameExcludes_ReturnsGood(DomainRangeInput input)
    => CanMerge_Good([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(DomainRangeInput input)
    => CanMerge_Errors([MakeItem(input, true), MakeAst(input)]);

  private readonly MergeDomainRanges _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainRange> MergerGroups => _merger;

  protected override IGqlpDomainRange MakeItem(DomainRangeInput input, bool excludes)
    => new DomainRangeAst(AstNulls.At, "", excludes, input.Lower, input.Upper);
}
