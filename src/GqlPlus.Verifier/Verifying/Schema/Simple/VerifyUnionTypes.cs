using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyUnionTypes(IVerifierRepository verifiers) : AstSimpleVerifier<IGqlpUnion, UsageContext, IGqlpUnionMember>(verifiers)
{
  protected override IEnumerable<IGqlpUnionMember> GetItems(IGqlpUnion usage)
    => usage.Items;

  protected override UsageContext MakeContext(IGqlpUnion usage, IAstType[] aliased, IMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpUnion usage, UsageContext context)
  {
    base.UsageValue(usage, context);

    foreach (IGqlpUnionMember member in usage.Items) {
      context.AddError(usage, "Union", $"'{member.Name}' not defined", CheckMember(usage.Name, member, context, CheckTypeLabel));
    }

    void CheckTypeLabel(string name, IAstType type)
      => context.AddError(
        usage,
        "union",
        $"Invalid Kind for {name}. Found {type?.Kind}",
        type is not IAstSimple);
  }

  private bool CheckMember(
    string name,
    IGqlpUnionMember member,
    UsageContext context,
    Action<string, IAstType>? checkType = null)
  {
    if (member.Name == name) {
      context.AddError(member, "Union Member", $"'{name}' cannot refer to " + (checkType is null ? "self, even recursively" : "self"));
      return false;
    } else if (context.GetTyped(member.Name, out IAstType? type)) {
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
