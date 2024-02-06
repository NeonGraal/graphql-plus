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
    var parent = GetParent(usage);
    if (usage.Name == parent) {
      context.AddError(usage, usage.Label, $"'{parent}' cannot be a child of itself");
    } else if (GetParentType(usage, parent, context, out var parentType)) {
      if (parentType.Label != usage.Label) {
        context.AddError(usage, usage.Label + " Parent", $"Type kind mismatch for {parent}. Found {parentType.Label}");
      }

      if (parentType is TAst ast && !CanMergeItems(usage, ast, context)) {
        context.AddError(usage, usage.Label + " Items", $"Can't merge Items for {usage.Name} into {parent} Items");
      }
    }
  }

  protected virtual bool GetParentType(TAst usage, string parent, TContext context, [NotNullWhen(true)] out AstType? type)
  {
    type = null;
    if (context.GetType(parent, out var defined)) {
      if (defined is AstType parentType) {
        if (parentType.Label == usage.Label) {
          type = parentType;

          if (CheckAstParent(usage, parentType as TAst, context)) {
            CheckRecursiveParent(usage, (AstType<TParent>)type, context);
            return true;
          }
        } else {
          context.AddError(usage, usage.Label + " Parent", $"'{parent}' invalid type. Found '{parentType.Label}'");
        }
      } else {
        context.AddError(usage, usage.Label + " Parent", $"'{parent}' invalid definition.");
      }
    } else if (!string.IsNullOrWhiteSpace(parent)) {
      context.AddError(usage, usage.Label + " Parent", $"'{parent}' not defined");
    }

    return false;
  }

  protected virtual bool CheckAstParent(TAst usage, [NotNullWhen(true)] TAst? parent, TContext context)
    => parent is not null;

  private void CheckRecursiveParent(TAst usage, AstType<TParent> child, TContext context)
  {
    var parent = GetParent(child);
    if (parent == usage.Name) {
      context.AddError(child, "Scalar Reference", $"'{usage.Name}' cannot be a child of itself, even recursively via {child.Name}");
    } else if (context.GetType(parent, out var type) && type is AstType<TParent> parentType && parentType.Label == child.Label) {
      if (CheckAstParent(usage, parentType as TAst, context)) {
        CheckRecursiveParent(usage, parentType, context);
      }
    }
  }

  protected abstract string GetParent(AstType<TParent> usage);
  protected abstract bool CanMergeItems(TAst usage, TAst parent, TContext context);
}
