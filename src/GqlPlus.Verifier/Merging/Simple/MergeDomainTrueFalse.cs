using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Simple;

internal class MergeDomainTrueFalse
  : BaseMerger<DomainTrueFalseAst>
{
  public override ITokenMessages CanMerge(IEnumerable<DomainTrueFalseAst> items)
    => new TokenMessages();
}
