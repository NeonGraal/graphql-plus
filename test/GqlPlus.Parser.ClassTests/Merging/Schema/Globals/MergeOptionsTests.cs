using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging.Globals;

namespace GqlPlus.Merging.Schema.Globals;

public class MergeOptionsTests
  : TestAliasedAsts<IGqlpSchemaOption>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSettingsCantMerge_ReturnsErrors(string name, string[] settings)
    => this
      .SkipUnless(settings)
      .CanMergeReturnsError(_settings)
      .CanMerge_Errors(
        new OptionDeclAst(AstNulls.At, name) with { Settings = settings.OptionSettings() },
        new OptionDeclAst(AstNulls.At, name));

  [Theory, RepeatData]
  public void Merge_TwoAstsWithSettings_CallsSettingsMerge(string name, string[] settings1, string[] settings2)
    => this
    .SkipNull(settings1)
    .SkipNull(settings2)
    .Merge_Expected([
        new OptionDeclAst(AstNulls.At, name) with { Settings = settings1.OptionSettings() },
      new OptionDeclAst(AstNulls.At, name) with { Settings = settings2.OptionSettings() }],
        new OptionDeclAst(AstNulls.At, name) with { Settings = settings1.Concat(settings2).Distinct().OptionSettings() })
      .MergeCalled(_settings, settings1.Concat(settings2).Distinct().Count());

  private readonly MergeOptions _merger;
  private readonly IMerge<IGqlpSchemaSetting> _settings;

  public MergeOptionsTests(ITestOutputHelper outputHelper)
  {
    _settings = Merger<IGqlpSchemaSetting>();

    _merger = new(outputHelper.ToLoggerFactory(), _settings);
  }

  protected override bool SkipDifferentNames => true;

  internal override GroupsMerger<IGqlpSchemaOption> MergerGroups => _merger;

  protected override IGqlpSchemaOption MakeAliased(string name, string[]? aliases = null, string description = "")
    => new OptionDeclAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
