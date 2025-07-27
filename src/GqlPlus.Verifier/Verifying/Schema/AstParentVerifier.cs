using System.Diagnostics.CodeAnalysis;

using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal abstract class AstParentVerifier<TAst, TParent, TContext>(
  IVerifyAliased<TAst> aliased
) : UsageVerifier<TAst, TContext>(aliased)
  where TAst : IGqlpType<TParent>
  where TParent : IGqlpDescribed, IEquatable<TParent>
  where TContext : UsageContext
{
  protected override void UsageValue(TAst usage, TContext context)
  {
    ParentUsage<TAst> input = new([], usage, "a child");
    CheckParent(input, usage, context, true);

    string parent = GetParent(usage);

    if (!parent.IsWhiteSpace()) {
      input = input.AddParent(parent);
      CheckMergeParent(input, context);
    }
  }

  protected virtual void CheckParentType(
    ParentUsage<TAst> input,
    TContext context,
    bool top,
    Action<TAst>? onParent = null)
  {
    if (string.IsNullOrWhiteSpace(input.Parent)) {
      return;
    }

    string outcome = "not defined";

    if (context.GetType(input.Parent, out IGqlpDescribed? defined)) {
      if (defined is IGqlpType astType) {
        CheckTypedParentType(input, context, top, onParent, astType);
        return;
      }

      outcome = "invalid definition";
    }

    context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' {outcome}", top);
  }

  private void CheckTypedParentType(ParentUsage<TAst> input, TContext context, bool top, Action<TAst>? onParent, IGqlpType astType)
  {
    if (CheckAstParentType(input, astType)) {
      if (astType is TAst parentType) {
        if (CheckAstParent(input.Usage, parentType, context)) {
          onParent?.Invoke(parentType);
        }
      }

      return;
    }

    context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' invalid type. Found '{astType.Label}'", top);
  }

  protected virtual bool CheckAstParentType(ParentUsage<TAst> input, IGqlpType astType)
    => astType.Label == input.UsageLabel;

  protected virtual bool CheckAstParent(TAst usage, [NotNullWhen(true)] TAst? parent, TContext context)
    => parent is not null;

  protected void CheckParent(ParentUsage<TAst> input, IGqlpType<TParent> child, TContext context, bool top)
  {
    string parent = GetParent(child);
    if (parent.IsWhiteSpace()) {
      return;
    }

    input = input.AddParent(parent);
    if (context.DifferentName(input, top ? null : child.Name)) {
      CheckParentType(input, context, top, parentType => {
        CheckParent(input, parentType, context, false);
        OnParentType(input, context, parentType, top);
      });
    }
  }

  protected virtual void OnParentType(ParentUsage<TAst> input, TContext context, TAst parentType, bool top)
    => context.AddError(
      input.Usage,
      input.UsageLabel + " Parent",
      $"Type kind mismatch for {input.Parent}. Found {parentType.Label}",
      top && parentType.Label != input.UsageLabel);

  protected abstract string GetParent(IGqlpType<TParent> usage);
  protected abstract void CheckMergeParent(ParentUsage<TAst> input, TContext context);
}
