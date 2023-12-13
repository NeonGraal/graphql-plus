using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeTypeParameters
  : DescribedsMerger<TypeParameterAst>
{
  protected override string ItemMatchKey(TypeParameterAst item)
    => "";
}
