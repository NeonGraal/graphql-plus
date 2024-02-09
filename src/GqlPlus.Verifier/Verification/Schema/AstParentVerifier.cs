using System.Diagnostics.CodeAnalysis;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification.Schema;

internal abstract class AstParentVerifier<TAst, TParent, TContext>(
  IVerifyAliased<TAst> aliased
) : UsageVerifier<TAst, AstType, TContext>(aliased)
  where TAst : AstType<TParent>
  where TParent : IEquatable<TParent>
  where TContext : UsageContext
{
  protected override void UsageValue(TAst usage, TContext context)
  {
    ParentUsage<TAst> input = new([], usage, "a child");
    CheckParent(input, usage, context, true);

    input = input.AddParent(GetParent(usage));
    if (!CanMergeParent(input, context)) {
      context.AddError(input.Usage, input.UsageLabel + " Child", $"Can't merge {input.UsageName} into Parent {input.Parent}");
    }
  }

  protected virtual void CheckParentType(
    ParentUsage<TAst> input,
    TContext context,
    bool top,
    Action<TAst>? onParent = null)
  {
    if (context.GetType(input.Parent, out var defined)) {
      if (defined is AstType astType) {
        if (astType.Label == input.UsageLabel) {
          var parentType = astType as TAst;
          if (CheckAstParent(input.Usage, parentType, context)) {
            onParent?.Invoke(parentType);
          }
        } else if (top) {
          context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' invalid type. Found '{astType.Label}'");
        }
      } else if (top) {
        context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' invalid definition.");
      }
    } else if (top && !string.IsNullOrWhiteSpace(input.Parent)) {
      context.AddError(input.Usage, input.UsageLabel + " Parent", $"'{input.Parent}' not defined");
    }
  }

  protected virtual bool CheckAstParent(TAst usage, [NotNullWhen(true)] TAst? parent, TContext context)
    => parent is not null;

  protected void CheckParent(ParentUsage<TAst> input, AstType<TParent> child, TContext context, bool top)
  {
    input = input.AddParent(GetParent(child));
    if (context.DifferentName(input, top ? null : child.Name)) {
      CheckParentType(input, context, top, parentType => {
        CheckParent(input, parentType, context, false);
        OnParentType(input, context, parentType, top);
      });
    }
  }

  protected virtual void OnParentType(ParentUsage<TAst> input, TContext context, TAst parentType, bool top)
  {
    if (top) {
      if (parentType.Label != input.UsageLabel) {
        context.AddError(input.Usage, input.UsageLabel + " Parent", $"Type kind mismatch for {input.Parent}. Found {parentType.Label}");
      }
    }
  }

  protected abstract string GetParent(AstType<TParent> usage);
  protected abstract bool CanMergeParent(ParentUsage<TAst> input, TContext context);
}
