using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnumValues
  : DescribedsMerger<EnumValueAst>
{
  protected override string ItemGroupKey(EnumValueAst item)
    => "";
}
