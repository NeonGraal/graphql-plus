using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyEnumsAliased(IVerifierRepository verifiers) : AliasedVerifier<IGqlpEnum>(verifiers)
{
  public override string Label => "Enums";
}
