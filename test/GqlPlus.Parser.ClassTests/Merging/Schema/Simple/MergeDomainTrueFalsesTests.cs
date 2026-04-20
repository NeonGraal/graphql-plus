using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainTrueFalsesTests(ITestOutputHelper outputHelper)
    : TestDomainItemMerger<IAstDomainTrueFalse, bool>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSameExcludes_ReturnsGood(bool input)
    => CanMerge_Good([MakeAst(input), MakeAst(input)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(bool input)
    => CanMerge_Errors([MakeItem(input, true), MakeAst(input)]);

  private readonly MergeDomainTrueFalse _merger = new(MergeRepo(outputHelper.ToLoggerFactory()));

  internal override GroupsMerger<IAstDomainTrueFalse> MergerGroups => _merger;

  protected override IAstDomainTrueFalse MakeItem(bool input, bool excludes)
    => new DomainTrueFalseAst(AstNulls.At, "", excludes, input);
}
