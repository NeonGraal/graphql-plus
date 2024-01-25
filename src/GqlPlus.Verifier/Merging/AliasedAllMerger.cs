using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal abstract class AliasedAllMerger<TBase, TAlias>
  : AliasedMerger<TAlias>, IMergeAll<TBase>
  where TAlias : TBase
  where TBase : AstAliased
{
  bool IMerge<TBase>.CanMerge(IEnumerable<TBase> items)
  {
    var aliases = items.OfType<TAlias>();

    return !aliases.Any() || CanMerge(aliases);
  }

  IEnumerable<TBase> IMerge<TBase>.Merge(IEnumerable<TBase> items)
    => Merge(items.OfType<TAlias>());
}
