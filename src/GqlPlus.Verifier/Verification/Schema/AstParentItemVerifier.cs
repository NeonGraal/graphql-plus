using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verification.Schema;

internal abstract class AstParentItemVerifier<TAst, TParent, TContext, TItem>(
  IVerifyAliased<TAst> aliased,
  IMerge<TItem> mergeItems
) : AstParentVerifier<TAst, TParent, TContext>(aliased)
  where TAst : AstType<TParent>
  where TParent : IEquatable<TParent>
  where TContext : UsageContext
  where TItem : AstBase
{
  protected override void CheckMergeParent(ParentUsage<TAst> input, TContext context)
  {
    var items = GetParentItems(input, input.Usage, context, GetItems).ToArray();

    if (items.Length > 0) {
      var failures = mergeItems.CanMerge(items);
      if (failures.Any()) {
        context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} into Parent {input.Parent}");
        context.Add(failures);
      }
    }
  }

  protected IEnumerable<T> GetParentItems<T>(ParentUsage<TAst> input, TAst child, TContext context, Func<TAst, IEnumerable<T>> getItems)
  {
    var items = getItems(child);
    if (input.DifferentName) {
      CheckParentType(input, context, false,
        parentType => items = GetParentItems(input.AddParent(GetParent(parentType)), parentType, context, getItems).Concat(items));
    }

    return items;
  }

  protected abstract IEnumerable<TItem> GetItems(TAst usage);
}
