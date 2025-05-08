using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainTrueFalsesTests(
  ITestOutputHelper outputHelper
) : TestDomainItemMerger<IGqlpDomainTrueFalse, bool>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameExcludes_ReturnsGood(bool input)
    => CanMerge_Good([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(bool input)
    => CanMerge_Errors([MakeItem(input, true), MakeAst(input)]);

  private readonly MergeDomainTrueFalse _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainTrueFalse> MergerGroups => _merger;

  protected override IGqlpDomainTrueFalse MakeItem(bool input, bool excludes)
    => new DomainTrueFalseAst(AstNulls.At, "", excludes, input);
}
