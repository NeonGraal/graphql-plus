using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyInputs(IVerify<InputAst> definition)
  : AliasedVerifier<InputAst>(definition)
{
  public override string Label => "Inputs";

  protected override object GroupKey(InputAst aliased) => TokenMessages.Empty;
}
