using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyEnumTypes(
  IVerifyAliased<EnumDeclAst> aliased
) : UsageAliasedVerifier<EnumDeclAst, EnumDeclAst>(aliased)
{
  protected override ITokenMessages UsageValue(EnumDeclAst usage, IMap<EnumDeclAst[]> byId)
    => usage.Extends is null || byId.ContainsKey(usage.Extends)
      ? new TokenMessages()
      : [usage.Error($"Invalid Enum Base. '{usage.Extends}' not defined.")];
}
