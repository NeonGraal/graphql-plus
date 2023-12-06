using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyScalars(IVerify<ScalarAst> definition)
  : AliasedVerifier<ScalarAst>(definition)
{
  public override string Label => "Scalars";

  protected override object GroupKey(ScalarAst aliased) => TokenMessages.Empty;
}
