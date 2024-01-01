using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeOptionSettingsTests
  : TestGroups<OptionSettingAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsValuesCantMerge_ReturnsFalse(string name)
  {
    _values.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([MakeDistinct(name), MakeDistinct(name)]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItems_CallsValuesMerge(string name)
  {
    Merge_Expected([MakeDistinct(name), MakeDistinct(name)], MakeDistinct(name));

    _values.ReceivedWithAnyArgs().Merge([]);
  }

  private readonly MergeOptionSettings _merger;
  private readonly IMerge<ConstantAst> _values;

  public MergeOptionSettingsTests()
  {
    _values = Merger<ConstantAst>();
    _merger = new(_values);
  }

  protected override GroupsMerger<OptionSettingAst> MergerGroups => _merger;

  protected override OptionSettingAst MakeDistinct(string name)
    => new(AstNulls.At, name, new FieldKeyAst(AstNulls.At, name));
}
