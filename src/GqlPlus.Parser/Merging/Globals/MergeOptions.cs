﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeOptions(
  ILoggerFactory logger,
  IMerge<OptionSettingAst> settings
) : AstAliasedMerger<IGqlpSchemaOption>(logger)
{

  protected override string ItemGroupKey(IGqlpSchemaOption item) => "Option";

  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(IGqlpSchemaOption item) => item.Name;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpSchemaOption> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyGroupCanMerge(d => d.Settings.ArrayOf<OptionSettingAst>(), s => s.Name, settings));

  protected override IGqlpSchemaOption MergeGroup(IEnumerable<IGqlpSchemaOption> group)
  {
    OptionDeclAst ast = (OptionDeclAst)base.MergeGroup(group);
    return ast with {
      Settings = [.. group.ManyGroupMerger(d => d.Settings.ArrayOf<OptionSettingAst>(), s => s.Name, settings)],
    };
  }
}