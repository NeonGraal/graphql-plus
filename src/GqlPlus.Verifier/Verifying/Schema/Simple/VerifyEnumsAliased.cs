using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumsAliased(IVerifierRepository verifiers) : AliasedVerifier<IAstEnum>(verifiers)
{
  public override string Label => "Enums";
}
