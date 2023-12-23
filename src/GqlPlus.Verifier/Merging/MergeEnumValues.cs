using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnumValues
  : AliasedMerger<EnumValueAst>
{
  protected override string ItemMatchKey(EnumValueAst item) => item.Name;
}
