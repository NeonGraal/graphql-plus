using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using NSubstitute;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeOptionsTests
  : TestAliased<OptionDeclAst>
{
  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSettingsCantMerge_ReturnsErrors(string name, string[] settings)
  {
    if (settings is null || settings.Length < 2) {
      return;
    }

    _settings.CanMerge([]).ReturnsForAnyArgs(ErrorMessages);

    CanMerge_Errors([
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings.OptionSettings() },
      new OptionDeclAst(AstNulls.At, name)]);
  }

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsWithSettings_CallsSettingsMerge(string name, string[] settings1, string[] settings2)
  {
    Merge_Expected([
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings1.OptionSettings() },
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings2.OptionSettings() }],
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings1.Concat(settings2).Distinct().OptionSettings() });

    _settings.ReceivedWithAnyArgs().Merge([]);
  }

  private readonly MergeOptions _merger;
  private readonly IMerge<OptionSettingAst> _settings;

  public MergeOptionsTests(ITestOutputHelper outputHelper)
  {
    _settings = Merger<OptionSettingAst>();

    _merger = new(outputHelper.ToLoggerFactory(), _settings);
  }

  protected override bool SkipDifferentNames => true;

  internal override GroupsMerger<OptionDeclAst> MergerGroups => _merger;

  protected override OptionDeclAst MakeAliased(string name, string[] aliases, string description = "")
    => new(AstNulls.At, name, description) { Aliases = aliases };
}
