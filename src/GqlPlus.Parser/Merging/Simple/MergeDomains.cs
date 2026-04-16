using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomains<TItemAst, TItem>(
  IMergerRepository mergers
) : AstSimpleMerger<IAstDomain, IAstDomain<TItem>, TItem>(mergers)
  , IDomainMerger<TItem>
  where TItemAst : AstAbbreviated, TItem
  where TItem : class, IAstDomainItem
{
  protected override string ItemMatchName => "Domain~Parent";
  protected override string ItemMatchKey(IAstDomain<TItem> item)
    => item.DomainKind.ToString() + item.Parent.Prefixed("~");

  internal override IAstDomain<TItem> SetItems(IAstDomain<TItem> input, IEnumerable<TItem> items)
  {
    AstDomain<TItemAst, TItem> ast = (AstDomain<TItemAst, TItem>)input;
    return ast with { Items = items.ArrayOf<TItemAst>() };
  }

  internal static MergeDomains<TItemAst, TItem> Factory(IMergerRepository m) => new(m);
}

internal interface IDomainMerger<TItem>
  : IMerge<IAstDomain<TItem>>
  where TItem : IAstDomainItem
{ }
