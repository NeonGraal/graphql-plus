using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeTypeParameters
  : NamedsMerger<TypeParameterAst>
{
  protected override string ItemMatchKey(TypeParameterAst item)
    => "";
}
