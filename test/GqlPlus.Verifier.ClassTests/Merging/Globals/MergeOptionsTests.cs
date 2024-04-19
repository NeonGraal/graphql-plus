using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Globals;

public class MergeOptionsTests
  : TestAliased<OptionDeclAst>
{
  [SkippableTheory, RepeatData(Repeats)]
  public void CanMerge_TwoAstsSettingsCantMerge_ReturnsErrors(string name, string[] settings)
    => this
      .SkipUnless(settings)
      .CanMergeReturnsError(_settings)
      .CanMerge_Errors(
        new OptionDeclAst(AstNulls.At, name) with { Settings = settings.OptionSettings() },
        new OptionDeclAst(AstNulls.At, name));

  [Theory, RepeatData(Repeats)]
  public void Merge_TwoAstsWithSettings_CallsSettingsMerge(string name, string[] settings1, string[] settings2)
    => Merge_Expected([
        new OptionDeclAst(AstNulls.At, name) with { Settings = settings1.OptionSettings() },
        new OptionDeclAst(AstNulls.At, name) with { Settings = settings2.OptionSettings() }],
        new OptionDeclAst(AstNulls.At, name) with { Settings = settings1.Concat(settings2).Distinct().OptionSettings() })
      .MergeCalled(_settings, settings1.Length + settings2.Length);

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
