using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomainTrueFalse
  : BaseMerger<DomainTrueFalseAst>
{
  public override ITokenMessages CanMerge(IEnumerable<DomainTrueFalseAst> items)
    => Messages();
}
