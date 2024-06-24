using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeDomains<TMember, TItem>(
  ILoggerFactory logger,
  IMerge<TItem> members
) : AstTypeMerger<IGqlpDomain, IGqlpDomain<TItem>, string, TItem>(logger, members)
  , IDomainMerger<TItem>
  where TMember : AstAbbreviated, TItem
  where TItem : class, IGqlpDomainItem
{
  protected override string ItemMatchName => "Domain~Parent";
  protected override string ItemMatchKey(IGqlpDomain<TItem> item)
    => item.DomainKind.ToString() + item.Parent.Prefixed("~");

  internal override IEnumerable<TItem> GetItems(IGqlpDomain<TItem> type)
    => type.Items;

  internal override IGqlpDomain<TItem> SetItems(IGqlpDomain<TItem> input, IEnumerable<TItem> items)
  {
    AstDomain<TMember, TItem> ast = (AstDomain<TMember, TItem>)input;
    return ast with { Members = items.ArrayOf<TMember>() };
  }
}

internal interface IDomainMerger<TItem>
  : IMerge<IGqlpDomain<TItem>>
  where TItem : IGqlpDomainItem
{ }
