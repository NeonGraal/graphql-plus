using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal abstract class AstSimpleMerger<TAst, TType, TItem>(
  ILoggerFactory logger,
  IMerge<TItem> items
) : AstTypeMerger<TAst, TType, IGqlpTypeRef, TItem>(logger, items)
  where TAst : IGqlpType
  where TType : IGqlpSimple<TItem>, TAst
  where TItem : IGqlpError
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(TType item)
    => (item.Parent?.Name).IfWhiteSpace();

  internal sealed override IEnumerable<TItem> GetItems(TType type)
    => type.Items;
}
