using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOutputs(IVerify<OutputDeclAst> definition)
  : AliasedVerifier<OutputDeclAst>(definition)
{
  public override string Label => "Outputs";

  protected override object GroupKey(OutputDeclAst aliased) => TokenMessages.Empty;
}
