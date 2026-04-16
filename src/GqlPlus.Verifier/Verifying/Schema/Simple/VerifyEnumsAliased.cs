using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumsAliased(IVerifierRepository verifiers) : AliasedVerifier<IAstEnum>(verifiers)
{
  public override string Label => "Enums";

  internal static VerifyEnumsAliased Factory(IVerifierRepository v) => new(v);
}
