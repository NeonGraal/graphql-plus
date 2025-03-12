using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Merging.Simple;


namespace GqlPlus.Schema.Simple;

public class MergeEnumsTests
  : TestTyped<IGqlpType, IGqlpEnum, string, IGqlpEnumItem>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsValuesCantMerge_ReturnsErrors(string name, string[] values)
    => this
      .SkipUnless(values)
      .CanMergeReturnsError(_enumMembers)
    .CanMerge_Errors(
      new EnumDeclAst(AstNulls.At, name, values.EnumMembers()),
      new EnumDeclAst(AstNulls.At, name, []));

  [Theory, RepeatData]
  public void Merge_TwoAstsValues_ReturnsExpected(string name, string[] values1, string[] values2)
  {
    EnumMemberAst[] combined = [.. values1.EnumMembers(), .. values2.EnumMembers()];

    Merge_Expected([
      new EnumDeclAst(AstNulls.At, name, values1.EnumMembers()),
      new EnumDeclAst(AstNulls.At, name, values2.EnumMembers())],
      new EnumDeclAst(AstNulls.At, name, combined));
  }

  private readonly IMerge<IGqlpEnumItem> _enumMembers;
  private readonly MergeEnums _merger;

  public MergeEnumsTests(ITestOutputHelper outputHelper)
  {
    _enumMembers = Merger<IGqlpEnumItem>();

    _merger = new(outputHelper.ToLoggerFactory(), _enumMembers);
  }

  internal override AstTypeMerger<IGqlpType, IGqlpEnum, string, IGqlpEnumItem> MergerTyped => _merger;

  protected override IGqlpEnum MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => new EnumDeclAst(AstNulls.At, name, description, []) { Aliases = aliases ?? [], Parent = parent, };
  protected override string MakeParent(string parent)
    => parent;
}
