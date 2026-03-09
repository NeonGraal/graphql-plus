using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeOptions(
  IMergerRepository mergers
) : AstAliasedMerger<IGqlpSchemaOption>(mergers.LoggerFactory)
{
  protected override string ItemGroupKey(IGqlpSchemaOption item) => "Option";

  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(IGqlpSchemaOption item) => item.Name;

  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpSchemaOption> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyGroupCanMerge(d => d.Settings, s => s.Name, mergers.MergerFor<IGqlpSchemaSetting>()));

  protected override IGqlpSchemaOption MergeGroup(IEnumerable<IGqlpSchemaOption> group)
  {
    OptionDeclAst ast = (OptionDeclAst)base.MergeGroup(group);
    return ast with {
      Settings = group.ManyGroupMerger(d => d.Settings, s => s.Name, mergers.MergerFor<IGqlpSchemaSetting>()).ArrayOf<OptionSettingAst>(),
    };
  }
}
