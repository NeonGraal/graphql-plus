using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal abstract class AstAliasedAllMerger<TBase, TAlias>(
  ILoggerFactory logger
) : AstAliasedMerger<TAlias>(logger), IMergeAll<TBase>
  where TAlias : TBase
  where TBase : AstAliased
{
  ITokenMessages IMerge<TBase>.CanMerge(IEnumerable<TBase> items)
  {
    var aliases = items.OfType<TAlias>();

    return aliases.Any() ? CanMerge(aliases) : new TokenMessages();
  }

  IEnumerable<TBase> IMerge<TBase>.Merge(IEnumerable<TBase> items)
    => Merge(items.OfType<TAlias>());
}
