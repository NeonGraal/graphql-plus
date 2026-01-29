using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyUnionTypes(
  IVerifyAliased<IGqlpUnion> aliased,
  IMerge<IGqlpUnionMember> mergeMembers
) : AstSimpleVerifier<IGqlpUnion, UsageContext, IGqlpUnionMember>(aliased, mergeMembers)
{
  protected override IEnumerable<IGqlpUnionMember> GetItems(IGqlpUnion usage)
    => usage.Items;

  protected override UsageContext MakeContext(IGqlpUnion usage, IGqlpType[] aliased, IMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpUnion usage, UsageContext context)
  {
    base.UsageValue(usage, context);

    foreach (IGqlpUnionMember member in usage.Items) {
      context.AddError(usage, "Union", $"'{member.Name}' not defined", CheckMember(usage.Name, member, context, CheckTypeLabel));
    }

    void CheckTypeLabel(string name, IGqlpType type)
      => context.AddError(
        usage,
        "union",
        $"Invalid Kind for {name}. Found {type?.Kind}",
        type is not IGqlpSimple);
  }

  private bool CheckMember(
    string name,
    IGqlpUnionMember member,
    UsageContext context,
    Action<string, IGqlpType>? checkType = null
  ) {
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

  protected override void CheckSelfMember(string name, IGqlpUnion usage, UsageContext context)
  {
    base.CheckSelfMember(name, usage, context);

    foreach (IGqlpUnionMember member in usage.Items) {
      CheckMember(name, member, context);
    }
  }
}
