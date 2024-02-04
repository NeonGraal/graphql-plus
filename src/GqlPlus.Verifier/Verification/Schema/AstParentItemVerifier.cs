using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class AstParentItemVerifier<TAst, TParent, TContext, TItem>(
  IVerifyAliased<TAst> aliased,
  IMerge<TItem> mergeItems
) : AstParentVerifier<TAst, TParent, TContext>(aliased)
  where TAst : AstType<TParent>
  where TParent : IEquatable<TParent>
  where TContext : UsageContext
{
  protected override bool CanMergeItems(TAst usage, TAst parent, TContext context)
  {
    var items = GetParentItems(parent, context).Concat(GetItems(usage)).ToArray();

    return items.Length == 0 || mergeItems.CanMerge(items);
  }

  private IEnumerable<TItem> GetParentItems(TAst usage, TContext context)
  {
    var items = GetItems(usage);

    var parent = GetParent(usage);
    if (!string.IsNullOrWhiteSpace(parent)) {
      if (GetParentType(usage, parent, context, out var parentType)
        && parentType is TAst ast) {
        return items.Concat(GetItems(ast));
      }
    }

    return items;
  }

  protected abstract IEnumerable<TItem> GetItems(TAst usage);
}
