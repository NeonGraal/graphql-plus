using GqlPlus.Verifier.Ast.Schema.Globals;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Globals;

internal class MergeOptions(
  ILoggerFactory logger,
  IMerge<OptionSettingAst> settings
) : AstAliasedMerger<OptionDeclAst>(logger)
{

  protected override string ItemGroupKey(OptionDeclAst item) => "Option";

  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(OptionDeclAst item) => item.Name;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, OptionDeclAst> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyGroupCanMerge(d => d.Settings, s => s.Name, settings));

  protected override OptionDeclAst MergeGroup(IEnumerable<OptionDeclAst> group)
    => base.MergeGroup(group) with {
      Settings = [.. group.ManyGroupMerger(d => d.Settings, s => s.Name, settings)],
    };
}
