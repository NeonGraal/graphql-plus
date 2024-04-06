using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeOptionSettings(
  IMerge<ConstantAst> values
) : GroupsMerger<OptionSettingAst>
{
  protected override string ItemGroupKey(OptionSettingAst item) => item.Name;

  [ExcludeFromCodeCoverage]
  protected override ITokenMessages CanMergeGroup(IGrouping<string, OptionSettingAst> group)
    => group.CanMerge(item => item.Value, values);

  protected override OptionSettingAst MergeGroup(IEnumerable<OptionSettingAst> group)
    => group.First() with {
      Value = group.Combine(item => item.Value, values)
    };
}
