using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnumValues
  : DescribedMerger<EnumValueAst>
{
  protected override string ItemGroupKey(EnumValueAst item)
    => "";
}
