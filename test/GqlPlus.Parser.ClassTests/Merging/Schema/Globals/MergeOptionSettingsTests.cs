using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging.Globals;

namespace GqlPlus.Merging.Schema.Globals;

public class MergeOptionSettingsTests
  : TestGroupsMerger<IGqlpSchemaSetting, string>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsValuesCantMerge_ReturnsErrors(string name)
    => this
      .CanMergeReturnsError(_values)
      .CanMerge_Errors([MakeAst(name), MakeAst(name)]);

  [Theory, RepeatData]
  public void Merge_TwoAsts_CallsValuesMerge(string name)
    => Merge_Expected([MakeAst(name), MakeAst(name)], MakeAst(name))
      .MergeCalled(_values);

  private readonly MergeOptionSettings _merger;
  private readonly IMerge<IGqlpConstant> _values;

  public MergeOptionSettingsTests()
  {
    _values = Merger<IGqlpConstant>();
    _merger = new(_values);
  }

  internal override GroupsMerger<IGqlpSchemaSetting> MergerGroups => _merger;

  protected override IGqlpSchemaSetting MakeAst(string input)
    => new OptionSettingAst(AstNulls.At, input, new(new FieldKeyAst(AstNulls.At, input)));
}
