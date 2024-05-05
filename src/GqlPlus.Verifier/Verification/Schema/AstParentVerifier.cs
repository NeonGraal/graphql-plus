using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Verification.Schema;

internal abstract class AstParentVerifier<TAst, TParent, TContext>(
  IVerifyAliased<TAst> aliased
) : UsageVerifier<TAst, IGqlpType, TContext>(aliased)
  where TAst : class, IGqlpType<TParent>
  where TParent : IEquatable<TParent>
  where TContext : UsageContext
{
  protected override void UsageValue(TAst usage, TContext context)
  {
    ParentUsage<TAst> input = new([], usage, "a child");
    CheckParent(input, usage, context, true);

    string parent = GetParent(usage);

    if (!string.IsNullOrWhiteSpace(parent)) {
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
    if (context.GetType(input.Parent, out IGqlpDescribed? defined)) {
      if (defined is AstType astType) {
        if (CheckAstParentType(input, astType)) {
          TAst? parentType = astType as TAst;
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

  protected virtual bool CheckAstParentType(ParentUsage<TAst> input, AstType astType)
    => astType.Label == input.UsageLabel;

  protected virtual bool CheckAstParent(TAst usage, [NotNullWhen(true)] TAst? parent, TContext context)
    => parent is not null;

  protected void CheckParent(ParentUsage<TAst> input, IGqlpType<TParent> child, TContext context, bool top)
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
    if (top && parentType.Label != input.UsageLabel) {
      context.AddError(input.Usage, input.UsageLabel + " Parent", $"Type kind mismatch for {input.Parent}. Found {parentType.Label}");
    }
  }

  protected abstract string GetParent(IGqlpType<TParent> usage);
  protected abstract void CheckMergeParent(ParentUsage<TAst> input, TContext context);
}
