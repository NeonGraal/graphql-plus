using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public class MergeEnumsTests
  : TestTypedMerger<IGqlpType, IGqlpEnum, string, IGqlpEnumLabel>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsValuesCantMerge_ReturnsErrors(string name, string[] values)
    => this
      .SkipUnless(values)
      .CanMergeReturnsError(_enumLabels)
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

  private readonly IMerge<IGqlpEnumLabel> _enumLabels;
  private readonly MergeEnums _merger;

  public MergeEnumsTests(ITestOutputHelper outputHelper)
  {
    _enumLabels = Merger<IGqlpEnumLabel>();

    _merger = new(outputHelper.ToLoggerFactory(), _enumLabels);
  }

  internal override AstTypeMerger<IGqlpType, IGqlpEnum, string, IGqlpEnumLabel> MergerTyped => _merger;

  protected override IGqlpEnum MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => new EnumDeclAst(AstNulls.At, name, description, []) { Aliases = aliases ?? [], Parent = parent, };
  protected override string MakeParent(string parent)
    => parent;
}
