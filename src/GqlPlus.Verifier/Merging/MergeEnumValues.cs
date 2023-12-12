using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnumValues
  : NamedsMerger<EnumValueAst>
{
  protected override string ItemMatchKey(EnumValueAst item)
    => "";
}
