using System.Diagnostics.CodeAnalysis;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal abstract class AstSimpleVerifier<TAst, TContext, TItem>(
  IVerifierRepository verifiers
) : AstParentItemVerifier<TAst, IAstTypeRef, TContext, TItem>(verifiers)
  where TAst : IAstSimple
  where TContext : UsageContext
  where TItem : IAstError
{
  protected sealed override string GetParent(IAstType<IAstTypeRef> usage)
    => (usage.Parent?.Name).IfWhiteSpace();

  protected override void UsageValue(TAst usage, TContext context)
  {
    base.UsageValue(usage, context);

    if (GetParentType(usage.Name, usage, context, out TAst? parentType)) {
      CheckSelfMember(usage.Name, parentType, context);
    }
  }

  protected virtual void CheckSelfMember(string name, TAst usage, UsageContext context)
  {
    if (GetParentType(name, usage, context, out TAst? parentType)) {
      CheckSelfMember(name, parentType, context);
    }
  }

  private static bool GetParentType(
    string name,
    TAst usage,
    UsageContext context,
    [NotNullWhen(true)] out TAst? parent)
  {
    parent = default;

    return usage.Parent?.Name != name && context.GetTyped(usage.Parent?.Name, out parent);
  }
}
