using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Merging;
using GqlPlus.Token;

namespace GqlPlus.Verification.Schema.Simple;

internal class VerifyEnumTypes(
  IVerifyAliased<EnumDeclAst> aliased,
  IMerge<EnumMemberAst> mergeMembers
) : AstParentItemVerifier<EnumDeclAst, string, UsageContext, EnumMemberAst>(aliased, mergeMembers)
{
  protected override IEnumerable<EnumMemberAst> GetItems(EnumDeclAst usage)
    => usage.Members;

  protected override string GetParent(AstType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(EnumDeclAst usage, AstType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);
}
