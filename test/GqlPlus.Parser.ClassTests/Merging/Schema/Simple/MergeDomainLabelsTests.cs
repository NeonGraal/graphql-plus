using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeDomainLabelsTests(
  ITestOutputHelper outputHelper
) : TestDomainItemMerger<IGqlpDomainLabel, string>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentExcludes_ReturnsErrors(string name)
    => CanMerge_Errors([MakeItem(name, true), MakeAst(name)]);

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentTypes_ReturnsGood(string name, string type1, string type2)
    => this
    .SkipEqual(type1, type2)
    .CanMerge_Good([MakeLabel(name, type1), MakeLabel(name, type2)]);

  [Theory, RepeatData]
  public void Merge_TwoAstsDifferentTypes_ReturnsExpected(string name, string type1, string type2)
    => this
      .SkipEqual(type1, type2)
      .Merge_Expected(
        [MakeLabel(name, type1), MakeLabel(name, type2)],
        MakeLabel(name, type1), MakeLabel(name, type2));

  private readonly MergeDomainLabels _merger = new(outputHelper.ToLoggerFactory());

  internal override GroupsMerger<IGqlpDomainLabel> MergerGroups => _merger;

  protected override IGqlpDomainLabel MakeItem(string input, bool excludes)
    => new DomainLabelAst(AstNulls.At, "", excludes, input);
  private DomainLabelAst MakeLabel(string item, string type)
    => new(AstNulls.At, "", false, item) { EnumType = type };
}
