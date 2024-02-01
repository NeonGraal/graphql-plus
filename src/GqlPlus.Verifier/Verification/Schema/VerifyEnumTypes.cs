using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyEnumTypes(
  IVerifyAliased<EnumDeclAst> aliased
) : AstParentVerifier<EnumDeclAst, string, UsageContext>(aliased)
{
  protected override string GetParent(AstType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(EnumDeclAst usage, AstType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);
}
