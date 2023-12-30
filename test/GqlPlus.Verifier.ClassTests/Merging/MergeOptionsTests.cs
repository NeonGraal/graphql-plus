using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeOptionsTests
  : TestAliased<OptionDeclAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSettingsCantMerge_ReturnsFalse(string name, string setting, string value)
  {
    _defaults.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      new OptionDeclAst(AstNulls.At, name) with { Settings = setting.OptionSettings(value) },
      new OptionDeclAst(AstNulls.At, name)]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsWithSettings_CallsSettingsMerge(string name, string setting1, string setting2, string value)
  {
    _defaults.Merge([]).ReturnsForAnyArgs([new FieldKeyAst(AstNulls.At, value)]);

    Merge_Expected([
      new OptionDeclAst(AstNulls.At, name) with { Settings = setting1.OptionSettings(value) },
      new OptionDeclAst(AstNulls.At, name) with { Settings = setting2.OptionSettings(value) }],
      new OptionDeclAst(AstNulls.At, name) with { Settings = setting2.OptionSettings(value) });

    _defaults.ReceivedWithAnyArgs(1).Merge([]);
  }

  private readonly MergeOptions _merger;
  private readonly IMerge<ConstantAst> _defaults;

  public MergeOptionsTests()
  {
    _defaults = Merger<ConstantAst>();

    _merger = new(_defaults);
  }

  protected override GroupsMerger<OptionDeclAst> MergerGroups => _merger;

  protected override OptionDeclAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description) { Aliases = aliases };
}
