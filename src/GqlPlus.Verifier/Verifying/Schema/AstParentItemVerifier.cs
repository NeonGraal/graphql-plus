using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema;

internal abstract class AstParentItemVerifier<TAst, TParent, TContext, TItem>(
  IVerifyAliased<TAst> aliased,
  IMerge<TItem> mergeItems
) : AstParentVerifier<TAst, TParent, TContext>(aliased)
  where TAst : IGqlpType<TParent>
  where TParent : IEquatable<TParent>
  where TContext : UsageContext
  where TItem : IGqlpError
{
  protected override void CheckMergeParent(ParentUsage<TAst> input, TContext context)
  {
    TItem[] items = [.. GetParentItems(input, input.Usage, context, GetItems)];

    if (items.Length > 0) {
      ITokenMessages failures = mergeItems.CanMerge(items);
      if (failures.Any()) {
        context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} into Parent {input.Parent}");
        context.Add(failures);
      }
    }
  }

  protected IEnumerable<T> GetParentItems<T>(ParentUsage<TAst> input, TAst child, TContext context, Func<TAst, IEnumerable<T>> getItems)
  {
    IEnumerable<T> items = getItems(child);
    if (input.DifferentName) {
      CheckParentType(input, context, false,
        parentType => items = GetParentItems(input.AddParent(GetParent(parentType)), parentType, context, getItems).Concat(items));
    }

    return items;
  }

  protected abstract IEnumerable<TItem> GetItems(TAst usage);
}
