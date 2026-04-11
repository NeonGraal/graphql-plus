using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyDomainsAliased(IVerifierRepository verifiers) : AliasedVerifier<IAstDomain>(verifiers)
{
  public override string Label => "Domains";
}
