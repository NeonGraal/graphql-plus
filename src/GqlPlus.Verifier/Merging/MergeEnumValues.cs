using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnumValues
  : GroupsMerger<EnumValueAst>
{
  protected override string ItemGroupKey(EnumValueAst item) => item.Name;

  protected override bool CanMergeGroup(IGrouping<string, EnumValueAst> group)
    => group.CanMerge(item => item.Description);

  protected override EnumValueAst MergeGroup(EnumValueAst[] items)
    => items.First() with {
      Description = items.MergeDescriptions(),
      Aliases = items.MergeAliases()
    };
}
