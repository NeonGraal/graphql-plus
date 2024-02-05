using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarFalse
  : BaseMerger<ScalarFalseAst>
{
  public override bool CanMerge(IEnumerable<ScalarFalseAst> items)
    => true;
}
