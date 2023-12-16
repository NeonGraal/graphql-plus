using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarTypes(
  IVerifyAliased<ScalarDeclAst> aliased
) : UsageAliasedVerifier<ScalarDeclAst, AstType>(aliased)
{
  protected override void UsageValue(ScalarDeclAst usage, IMap<AstType[]> byId, ITokenMessages errors)
  {
  }
}
