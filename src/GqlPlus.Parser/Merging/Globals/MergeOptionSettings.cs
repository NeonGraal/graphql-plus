using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeOptionSettings(
  IMerge<ConstantAst> values
) : GroupsMerger<OptionSettingAst>
{
  protected override string ItemGroupKey(OptionSettingAst item) => item.Name;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, OptionSettingAst> group)
    => group.CanMerge(item => item.Value, values);

  protected override OptionSettingAst MergeGroup(IEnumerable<OptionSettingAst> group)
    => group.First() with {
      Value = group.Combine(item => item.Value, values)
    };
}
