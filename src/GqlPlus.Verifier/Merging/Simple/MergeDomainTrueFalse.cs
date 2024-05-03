using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Token;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainTrueFalse
  : BaseMerger<DomainTrueFalseAst>
{
  public override ITokenMessages CanMerge(IEnumerable<DomainTrueFalseAst> items)
    => new TokenMessages();
}
