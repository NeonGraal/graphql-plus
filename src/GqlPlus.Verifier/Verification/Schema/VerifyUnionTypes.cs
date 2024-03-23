using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyUnionTypes(
  IVerifyAliased<UnionDeclAst> aliased,
  IMerge<UnionMemberAst> mergeMembers
) : AstParentItemVerifier<UnionDeclAst, string, UsageContext, UnionMemberAst>(aliased, mergeMembers)
{
  protected override IEnumerable<UnionMemberAst> GetItems(UnionDeclAst usage)
    => usage.Members;

  protected override string GetParent(AstType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(UnionDeclAst usage, AstType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(UnionDeclAst usage, UsageContext context)
  {
    foreach (var member in usage.Members) {
      if (CheckMember(usage.Name, member, context, CheckTypeLabel)) {
        context.AddError(usage, "Union", $"'{member.Name}' not defined");
      }
    }

    if (GetParentType(usage.Name, usage, context, out var parentType)) {
      CheckSelfMember(usage.Name, parentType, context);
    }

    void CheckTypeLabel(string name, AstType type)
    {
      if (type is not AstSimple and not SpecialTypeAst) {
        context.AddError(usage, "union", $"Type kind mismatch for {name}. Found {type?.Label}");
      }
    }
  }

  private static bool CheckMember(string name, UnionMemberAst member, UsageContext context, Action<string, AstType>? checkType = null)
  {
    if (member.Name == name) {
      context.AddError(member, "Union Member", $"'{name}' cannot refer to " + (checkType is null ? "self, even recursively" : "self"));
      return false;
    } else if (context.GetType(member.Name, out var alternate) && alternate is AstType type) {
      if (type is UnionDeclAst typeUnion) {
        CheckSelfMember(name, typeUnion, context);
      } else {
        checkType?.Invoke(member.Name, type);
      }

      return false;
    }

    return true;
  }

  private static void CheckSelfMember(string name, UnionDeclAst usage, UsageContext context)
  {
    foreach (var member in usage.Members) {
      CheckMember(name, member, context);
    }

    if (GetParentType(name, usage, context, out var parentType)) {
      CheckSelfMember(name, parentType, context);
    }
  }

  private static bool GetParentType(string name, UnionDeclAst usage, UsageContext context, [NotNullWhen(true)] out UnionDeclAst? parent)
  {
    parent = null;

    if (usage.Parent != name && context.GetType(usage.Parent, out var parentType) && parentType is UnionDeclAst usageParent) {
      parent = usageParent;
    }

    return parent is not null;
  }
}
