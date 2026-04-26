using GqlPlus.Ast.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema;

internal abstract class AstParentItemVerifier<TAst, TParent, TContext, TItem>(
  IVerifierRepository verifiers
) : AstParentVerifier<TAst, TParent, TContext>(verifiers)
  where TAst : IAstType<TParent>
  where TParent : IAstDescribed, IEquatable<TParent>
  where TContext : UsageContext
  where TItem : IAstError
{
  private readonly IMerge<TItem> _mergeItems = verifiers.MergerFor<TItem>();

  protected override void CheckMergeParent(SelfUsage<TAst> input, TContext context)
  {
    TItem[] items = [.. GetParentItems(input, input.Usage, context, GetItems)];

    if (items.Length > 0) {
      IMessages failures = _mergeItems.CanMerge(items);
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
