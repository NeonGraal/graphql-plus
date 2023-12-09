using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeParameters
  : DescribedMerger<ParameterAst>
{
  public override bool CanMerge(ParameterAst[] items)
    => items.Select(i => i.Modifiers).Distinct().Count() == 1 && base.CanMerge(items);
}
