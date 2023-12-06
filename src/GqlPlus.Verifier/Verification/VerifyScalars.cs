using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyScalars(IVerify<ScalarDeclAst> definition)
  : AliasedVerifier<ScalarDeclAst>(definition)
{
  public override string Label => "Scalars";

  protected override object GroupKey(ScalarDeclAst aliased) => TokenMessages.Empty;
}
