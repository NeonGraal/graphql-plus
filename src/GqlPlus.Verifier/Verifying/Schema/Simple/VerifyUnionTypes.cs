using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyUnionTypes(IVerifierRepository verifiers) : AstSimpleVerifier<IAstUnion, UsageContext, IAstUnionMember>(verifiers)
{
  protected override IEnumerable<IAstUnionMember> GetItems(IAstUnion usage)
    => usage.Items;

  protected override UsageContext MakeContext(IAstUnion usage, IAstType[] aliased, IMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IAstUnion usage, UsageContext context)
  {
    base.UsageValue(usage, context);

    foreach (IAstUnionMember member in usage.Items) {
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
    IAstUnionMember member,
    UsageContext context,
    Action<string, IAstType>? checkType = null)
  {
    if (member.Name == name) {
      context.AddError(member, "Union Member", $"'{name}' cannot refer to " + (checkType is null ? "self, even recursively" : "self"));
      return false;
    } else if (context.GetTyped(member.Name, out IAstType? type)) {
      if (type is IAstUnion typeUnion) {
        CheckSelfMember(name, typeUnion, context);
      } else {
        checkType?.Invoke(member.Name, type);
      }

      return false;
    }

    return true;
  }

  protected override void CheckSelfMember(string name, IAstUnion usage, UsageContext context)
  {
    base.CheckSelfMember(name, usage, context);

    foreach (IAstUnionMember member in usage.Items) {
      CheckMember(name, member, context);
    }
  }
}
