using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema;

internal abstract class AstParentItemVerifier<TAst, TParent, TContext, TItem>(
  IVerifyAliased<TAst> aliased,
  IMerge<TItem> mergeItems
) : AstParentVerifier<TAst, TParent, TContext>(aliased)
  where TAst : IGqlpType<TParent>
  where TParent : IGqlpDescribed, IEquatable<TParent>
  where TContext : UsageContext
  where TItem : IGqlpError
{
  protected override void CheckMergeParent(SelfUsage<TAst> input, TContext context)
  {
    TItem[] items = [.. GetParentItems(input, input.Usage, context, GetItems)];

    if (items.Length > 0) {
      IMessages failures = mergeItems.CanMerge(items);
      if (failures.Any()) {
        context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} into Parent {input.Current}");
        context.Add(failures);
      }
    }
  }

  protected IEnumerable<T> GetParentItems<T>(
    SelfUsage<TAst> input,
    TAst child,
    TContext context,
    Func<TAst, IEnumerable<T>> getItems)
  {
    IEnumerable<T> items = getItems(child);
    if (input.DifferentName) {
      CheckParentType(input, context, false,
        parentType => items = GetParentItems(input.AddNext(GetParent(parentType)), parentType, context, getItems).Concat(items));
    }

    return items;
  }

  protected abstract IEnumerable<TItem> GetItems(TAst usage);
}
