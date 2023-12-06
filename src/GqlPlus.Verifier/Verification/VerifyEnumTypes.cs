using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyEnumTypes : UsageAliasedVerifier<EnumDeclAst, AstType>
{
  //  protected override string UsageKey(EnumAst item) => item.Extends ?? "";
  protected override ITokenMessages UsageValue(EnumDeclAst usage, IMap<AstType[]> byId) => TokenMessages.Empty;
}
