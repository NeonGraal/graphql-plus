using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal abstract class AstTypeMerger<TBase, TType, TParent, TItem>(
  ILoggerFactory logger,
  IMerge<TItem> mergeItems
) : AstAliasedMerger<TType>(logger), IMergeAll<TBase>
  where TBase : AstType
  where TType : AstType<TParent>, TBase
  where TParent : IEquatable<TParent>
  where TItem : AstBase
{
  internal abstract IEnumerable<TItem> GetItems(TType type);

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TType> group)
    => base.CanMergeGroup(group)
    .Add(group.ManyCanMerge(GetItems, mergeItems));

  internal abstract TType SetItems(TType input, IEnumerable<TItem> items);

  protected override TType MergeGroup(IEnumerable<TType> group)
  {
    var items = group.ManyMerge(GetItems, mergeItems);

    return SetItems(base.MergeGroup(group), items);
  }

  ITokenMessages IMerge<TBase>.CanMerge(IEnumerable<TBase> items)
  {
    var aliases = items.OfType<TType>();

    return aliases.Any() ? CanMerge(aliases) : new TokenMessages();
  }

  IEnumerable<TBase> IMerge<TBase>.Merge(IEnumerable<TBase> items)
    => Merge(items.OfType<TType>());
}
