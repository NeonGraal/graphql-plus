using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOutputTypes : UsageAliasedVerifier<OutputDeclAst, AstType>
{
  // protected override string UsageKey(OutputAst item) => item.Extends?.Name ?? "";
  protected override ITokenMessages UsageValue(OutputDeclAst usage, IMap<AstType[]> byId) => new TokenMessages();
}
