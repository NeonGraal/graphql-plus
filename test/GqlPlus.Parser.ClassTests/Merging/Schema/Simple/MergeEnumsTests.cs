using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeEnumsTests
  : TestSimpleMerger<IGqlpType, IGqlpEnum, IGqlpEnumLabel, string>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsValuesCantMerge_ReturnsErrors(string name, string[] values)
    => this
      .SkipUnless(values)
      .CanMergeReturnsError(MergeItems)
      .CanMerge_Errors(
        new EnumDeclAst(AstNulls.At, name, values.EnumLabels()),
        new EnumDeclAst(AstNulls.At, name, []));

  [Theory, RepeatData]
  public void Merge_TwoAstsValues_ReturnsExpected(string name, string[] values1, string[] values2)
  {
    EnumLabelAst[] combined = [.. values1.EnumLabels(), .. values2.EnumLabels()];

    Merge_Expected([
      new EnumDeclAst(AstNulls.At, name, values1.EnumLabels()),
      new EnumDeclAst(AstNulls.At, name, values2.EnumLabels())],
      new EnumDeclAst(AstNulls.At, name, combined));
  }

  private readonly MergeEnums _merger;

  public MergeEnumsTests(ITestOutputHelper outputHelper)
    => _merger = new(outputHelper.ToLoggerFactory(), MergeItems);

  internal override AstSimpleMerger<IGqlpType, IGqlpEnum, IGqlpEnumLabel> MergerSimple => _merger;

  protected override IGqlpEnumLabel[] MakeItems(string input)
    => new[] { input }.EnumLabels();
  protected override IGqlpEnum MakeSimple(string name, string[]? aliases = null, string description = "", IGqlpTypeRef? parent = null, IEnumerable<IGqlpEnumLabel>? items = null)
    => new EnumDeclAst(AstNulls.At, name, description, [.. items ?? []]) {
      Aliases = aliases ?? [],
      Parent = parent,
    };
}
