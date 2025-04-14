using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainLabelsTests(
  ITestOutputHelper outputHelper
) : TestDomainItemAsts<IGqlpDomainLabel, string>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([MakeItem(name, true), MakeAst(name)]);

  private readonly MergeDomainLabels _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainLabel> MergerGroups => _merger;

  protected override IGqlpDomainLabel MakeItem(string input, bool excludes)
    => new DomainLabelAst(AstNulls.At, "", excludes, input);
}
