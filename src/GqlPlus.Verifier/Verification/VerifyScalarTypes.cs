using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyScalarTypes : UsageAliasedVerifier<ScalarDeclAst, AstType>
{
  //  protected override string UsageKey(ScalarAst item) => item.Kind.ToString();
  protected override ITokenMessages UsageValue(ScalarDeclAst usage, IMap<AstType[]> byId) => new TokenMessages();
}
