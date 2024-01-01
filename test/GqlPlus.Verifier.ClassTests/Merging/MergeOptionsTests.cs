using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;

namespace GqlPlus.Verifier.Merging;

public class MergeOptionsTests
  : TestAliased<OptionDeclAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSettingsCantMerge_ReturnsFalse(string name, string[] settings)
  {
    if (settings.Length < 2) {
      return;
    }

    _settings.CanMerge([]).ReturnsForAnyArgs(false);

    CanMerge_False([
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings.OptionSettings() },
      new OptionDeclAst(AstNulls.At, name)]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoItemsWithSettings_CallsSettingsMerge(string name, string[] settings1, string[] settings2)
  {
    Merge_Expected([
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings1.OptionSettings() },
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings2.OptionSettings() }],
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings1.Concat(settings2).Distinct().OptionSettings() });

    _settings.ReceivedWithAnyArgs().Merge([]);
  }

  private readonly MergeOptions _merger;
  private readonly IMerge<OptionSettingAst> _settings;

  public MergeOptionsTests()
  {
    _settings = Merger<OptionSettingAst>();

    _merger = new(_settings);
  }

  protected override GroupsMerger<OptionDeclAst> MergerGroups => _merger;

  protected override OptionDeclAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description) { Aliases = aliases };
}
