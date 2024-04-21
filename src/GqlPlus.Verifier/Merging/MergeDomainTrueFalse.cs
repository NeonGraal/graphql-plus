using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeDomainTrueFalse
  : BaseMerger<DomainTrueFalseAst>
{
  public override ITokenMessages CanMerge(IEnumerable<DomainTrueFalseAst> items)
    => new TokenMessages();
}
