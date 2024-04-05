using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeOptions(
  ILoggerFactory logger,
  IMerge<OptionSettingAst> settings
) : AstAliasedMerger<OptionDeclAst>(logger)
{
  protected override string ItemMatchKey(OptionDeclAst item)
    => item.Name;

  protected override bool CanMergeGroup(IGrouping<string, OptionDeclAst> group)
    => base.CanMergeGroup(group)
      && group.ManyGroupCanMerge(d => d.Settings, s => s.Name, settings);

  protected override OptionDeclAst MergeGroup(IEnumerable<OptionDeclAst> group)
    => base.MergeGroup(group) with {
      Settings = [.. group.ManyGroupMerger(d => d.Settings, s => s.Name, settings)],
    };
}
