using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyInputs(IVerify<InputDeclAst> definition)
  : AliasedVerifier<InputDeclAst>(definition)
{
  public override string Label => "Inputs";

  protected override object GroupKey(InputDeclAst aliased) => TokenMessages.Empty;
}
