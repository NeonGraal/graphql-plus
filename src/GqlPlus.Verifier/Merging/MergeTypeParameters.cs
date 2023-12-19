using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeTypeParameters
  : DescribedsMerger<TypeParameterAst>
{
  public override TypeParameterAst Merge(TypeParameterAst[] items)
    => items.First() with { Description = MergeDescriptions(items) };
}
