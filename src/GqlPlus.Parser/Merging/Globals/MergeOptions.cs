using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeOptions(
  IMergerRepository mergers
) : AstAliasedMerger<IAstSchemaOption>(mergers)
{
  protected override string ItemGroupKey(IAstSchemaOption item) => "Option";

  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(IAstSchemaOption item) => item.Name;

  protected override IMessages CanMergeGroup(IGrouping<string, IAstSchemaOption> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyGroupCanMerge(d => d.Settings, s => s.Name, mergers.MergerFor<IAstSchemaSetting>()));

  protected override IAstSchemaOption MergeGroup(IEnumerable<IAstSchemaOption> group)
  {
    OptionDeclAst ast = (OptionDeclAst)base.MergeGroup(group);
    return ast with {
      Settings = group.ManyGroupMerger(d => d.Settings, s => s.Name, mergers.MergerFor<IAstSchemaSetting>()).ArrayOf<OptionSettingAst>(),
    };
  }

  internal static MergeOptions Factory(IMergerRepository m) => new(m);
}
