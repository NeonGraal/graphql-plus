using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarTypes(
  IVerifyAliased<ScalarDeclAst> aliased
) : UsageAliasedVerifier<ScalarDeclAst, AstType>(aliased)
{

  //  protected override string UsageKey(ScalarAst item) => item.Kind.ToString();
  protected override ITokenMessages UsageValue(ScalarDeclAst usage, IMap<AstType[]> byId) => new TokenMessages();
}
