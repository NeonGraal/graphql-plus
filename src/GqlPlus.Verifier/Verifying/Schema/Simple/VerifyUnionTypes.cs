using System.Diagnostics.CodeAnalysis;

using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyUnionTypes(
  IVerifyAliased<IGqlpUnion> aliased,
  IMerge<IGqlpUnionMember> mergeMembers
) : AstParentItemVerifier<IGqlpUnion, string, UsageContext, IGqlpUnionMember>(aliased, mergeMembers)
{
  protected override IEnumerable<IGqlpUnionMember> GetItems(IGqlpUnion usage)
    => usage.Items;

  protected override string GetParent(IGqlpType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(IGqlpUnion usage, IGqlpType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpUnion usage, UsageContext context)
  {
    base.UsageValue(usage, context);

    foreach (IGqlpUnionMember member in usage.Items) {
      context.AddError(usage, "Union", $"'{member.Name}' not defined", CheckMember(usage.Name, member, context, CheckTypeLabel));
    }

    if (GetParentType(usage.Name, usage, context, out IGqlpUnion? parentType)) {
      CheckSelfMember(usage.Name, parentType, context);
    }

    void CheckTypeLabel(string name, IGqlpType type)
      => context.AddError(
        usage,
        "union",
        $"Type kind mismatch for {name}. Found {type?.Label}",
        type is not IGqlpSimple);
  }

  private static bool CheckMember(string name, IGqlpUnionMember member, UsageContext context, Action<string, IGqlpType>? checkType = null)
  {
    if (member.Name == name) {
      context.AddError(member, "Union Member", $"'{name}' cannot refer to " + (checkType is null ? "self, even recursively" : "self"));
      return false;
    } else if (context.GetTyped(member.Name, out IGqlpType? type)) {
      if (type is IGqlpUnion typeUnion) {
        CheckSelfMember(name, typeUnion, context);
      } else {
        checkType?.Invoke(member.Name, type);
      }

      return false;
    }

    return true;
  }

  private static void CheckSelfMember(string name, IGqlpUnion usage, UsageContext context)
  {
    foreach (IGqlpUnionMember member in usage.Items) {
      CheckMember(name, member, context);
    }

    if (GetParentType(name, usage, context, out IGqlpUnion? parentType)) {
      CheckSelfMember(name, parentType, context);
    }
  }

  private static bool GetParentType(string name, IGqlpUnion usage, UsageContext context, [NotNullWhen(true)] out IGqlpUnion? parent)
  {
    parent = null;

    return usage.Parent != name && context.GetTyped(usage.Parent, out parent);
  }
}
