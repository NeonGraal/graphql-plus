using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Merging.Globals;

namespace GqlPlus.Merging.Schema.Globals;

public class MergeOptionsTests
  : TestAliasedMerger<IAstSchemaOption>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsSettingsCantMerge_ReturnsErrors(string name, string[] settings)
    => this
      .SkipShortArray(settings)
      .CanMergeReturnsError(_settings)
      .CanMerge_Errors(
        new OptionDeclAst(AstNulls.At, name) with { Settings = settings.OptionSettings() },
        new OptionDeclAst(AstNulls.At, name));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsDifferentNames_ReturnsErrors(string input1, string input2)
  {
    Assert.SkipWhen(input1 is null || input1 == input2, "same input");

    CanMerge_Errors([MakeAst(input1), MakeAst(input2)]);
  }

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
  private readonly IMerge<IAstSchemaSetting> _settings;

  public MergeOptionsTests(ITestOutputHelper outputHelper)
  {
    _settings = Merger<IAstSchemaSetting>();

    IMergerRepository mergers = MergeRepo(outputHelper.ToLoggerFactory());
    mergers.MergerFor<IAstSchemaSetting>().Returns(_settings);
    _merger = new(mergers);
  }

  protected override bool SkipDifferentInput => true;

  internal override GroupsMerger<IAstSchemaOption> MergerGroups => _merger;

  protected override IAstSchemaOption MakeAliased(string name, string[]? aliases = null, string description = "")
    => new OptionDeclAst(AstNulls.At, name, description) { Aliases = aliases ?? [] };
}
