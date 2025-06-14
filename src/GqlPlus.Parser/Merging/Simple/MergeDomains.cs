using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomains<TItemAst, TItem>(
  ILoggerFactory logger,
  IMerge<TItem> items
) : AstSimpleMerger<IGqlpDomain, IGqlpDomain<TItem>, TItem>(logger, items)
  , IDomainMerger<TItem>
  where TItemAst : AstAbbreviated, TItem
  where TItem : class, IGqlpDomainItem
{
  protected override string ItemMatchName => "Domain~Parent";
  protected override string ItemMatchKey(IGqlpDomain<TItem> item)
    => item.DomainKind.ToString() + item.Parent.Prefixed("~");

  internal override IGqlpDomain<TItem> SetItems(IGqlpDomain<TItem> input, IEnumerable<TItem> items)
  {
    AstDomain<TItemAst, TItem> ast = (AstDomain<TItemAst, TItem>)input;
    return ast with { Items = items.ArrayOf<TItemAst>() };
  }
}

internal interface IDomainMerger<TItem>
  : IMerge<IGqlpDomain<TItem>>
  where TItem : IGqlpDomainItem
{ }
