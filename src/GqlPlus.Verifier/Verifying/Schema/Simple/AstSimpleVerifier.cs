using System.Diagnostics.CodeAnalysis;

using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal abstract class AstSimpleVerifier<TAst, TContext, TItem>(
  IVerifyAliased<TAst> aliased,
  IMerge<TItem> mergeMembers
) : AstParentItemVerifier<TAst, IGqlpTypeRef, TContext, TItem>(aliased, mergeMembers)
  where TAst : IGqlpSimple
  where TContext : UsageContext
  where TItem : IGqlpError
{
  protected sealed override string GetParent(IGqlpType<IGqlpTypeRef> usage)
    => (usage.Parent?.Name).IfWhitespace();

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

  private static bool GetParentType(string name, TAst usage, UsageContext context, [NotNullWhen(true)] out TAst? parent)
  {
    parent = default;

    return usage.Parent?.Name != name && context.GetTyped(usage.Parent?.Name, out parent);
  }
}
