using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeScalarTrueFalse
  : BaseMerger<ScalarTrueFalseAst>
{
  public override ITokenMessages CanMerge(IEnumerable<ScalarTrueFalseAst> items)
    => new TokenMessages();
}
