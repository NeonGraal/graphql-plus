using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarTrueFalse
  : BaseMerger<ScalarTrueFalseAst>
{
  public override bool CanMerge(IEnumerable<ScalarTrueFalseAst> items)
    => true;
}
