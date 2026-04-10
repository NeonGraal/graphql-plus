using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeEnumsTests
  : TestSimpleMerger<IAstType, IAstEnum, IAstEnumLabel, string>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsValuesCantMerge_ReturnsErrors(string name, string[] values)
    => this
      .SkipShortArray(values)
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
  {
    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IAstEnumLabel>().Returns(MergeItems);
    _merger = new(mergers);
  }

  internal override AstSimpleMerger<IAstType, IAstEnum, IAstEnumLabel> MergerSimple => _merger;

  protected override IAstEnumLabel[] MakeItems(string input)
    => new[] { input }.EnumLabels();
  protected override IAstEnum MakeSimple(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, IEnumerable<IAstEnumLabel>? items = null)
    => new EnumDeclAst(AstNulls.At, name, description, [.. items ?? []]) {
      Aliases = aliases ?? [],
      Parent = parent,
    };
}
