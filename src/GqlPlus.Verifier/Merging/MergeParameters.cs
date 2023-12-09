using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeParameters
  : DescribedMerger<ParameterAst>
{
  protected override string ItemGroupKey(ParameterAst item)
    => item.Modifiers.AsString().Joined();
}
