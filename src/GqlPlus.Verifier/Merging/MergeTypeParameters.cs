using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeTypeParameters
  : DescribedMerger<TypeParameterAst>
{
  protected override string ItemGroupKey(TypeParameterAst item)
    => "";
}
