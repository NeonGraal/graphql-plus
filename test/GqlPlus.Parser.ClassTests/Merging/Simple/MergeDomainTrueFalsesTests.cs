using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainTrueFalsesTests(
  ITestOutputHelper outputHelper
) : TestAbbreviated<IGqlpDomainTrueFalse, bool>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSameExcludes_ReturnsGood(bool input)
    => CanMerge_Good([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(bool input)
    => CanMerge_Errors([MakeAst(input) with { Excludes = true }, MakeAst(input)]);

  private readonly MergeDomainTrueFalse _merger = new(outputHelper.ToLoggerFactory());

  protected override IMerge<IGqlpDomainTrueFalse> MergerBase => _merger;

  protected override DomainTrueFalseAst MakeAst(bool input)
    => new(AstNulls.At, false, input);
}
