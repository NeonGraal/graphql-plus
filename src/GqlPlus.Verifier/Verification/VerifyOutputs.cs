using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOutputs(IVerify<OutputAst> definition)
  : AliasedVerifier<OutputAst>(definition)
{
  public override string Label => "Outputs";

  protected override object GroupKey(OutputAst aliased) => TokenMessages.Empty;
}
