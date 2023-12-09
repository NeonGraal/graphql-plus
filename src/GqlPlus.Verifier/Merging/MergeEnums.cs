using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnums
  : DescribedMerger<EnumDeclAst>
{
  protected override string ItemGroupKey(EnumDeclAst item)
    => item.Extends ?? "";
}
