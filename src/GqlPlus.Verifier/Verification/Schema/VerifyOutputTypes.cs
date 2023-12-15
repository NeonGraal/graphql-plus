using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyOutputTypes(
  IVerifyAliased<OutputDeclAst> aliased
) : UsageAliasedVerifier<OutputDeclAst, AstType>(aliased)
{

  // protected override string UsageKey(OutputAst item) => item.Extends?.Name ?? "";
  protected override ITokenMessages UsageValue(OutputDeclAst usage, IMap<AstType[]> byId) => new TokenMessages();
}
