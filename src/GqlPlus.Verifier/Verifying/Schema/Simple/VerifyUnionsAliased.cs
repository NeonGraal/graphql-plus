using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

internal class VerifyUnionsAliased(IVerifierRepository verifiers) : AliasedVerifier<IAstUnion>(verifiers)
{
  public override string Label => "Unions";
}
