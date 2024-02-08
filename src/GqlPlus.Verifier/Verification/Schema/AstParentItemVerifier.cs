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
  protected override bool CanMergeParent(ParentUsage<TAst> input, TAst parent, TContext context)
  {
    var usageItems = GetItems(input.Usage);
    input = input.AddParent(GetParent(parent)) with { Usage = parent };
    var items = GetParentItems(input, context).Concat(usageItems).ToArray();

    return items.Length == 0 || mergeItems.CanMerge(items);
  }

  private IEnumerable<TItem> GetParentItems(ParentUsage<TAst> input, TContext context)
  {
    var items = GetItems(input.Usage);
    CheckParentType(input, context, true,
      parentType => items = items.Concat(GetItems(parentType)));
    return items;
  }

  protected abstract IEnumerable<TItem> GetItems(TAst usage);
}
