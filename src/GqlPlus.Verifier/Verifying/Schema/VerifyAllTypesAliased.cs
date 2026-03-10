using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypesAliased(IVerifierRepository verifiers) : GroupedVerifier<IGqlpType>(verifiers)
{
  public override string Label => "Types";
}
