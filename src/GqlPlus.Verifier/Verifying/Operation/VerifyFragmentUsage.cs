using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyFragmentUsage(IVerifierRepository verifiers) : IdentifiedVerifier<IGqlpSpread, IAstFragment>(verifiers)
{
  public override string Label => "Spread";

  public override string UsageKey(IGqlpSpread item) => item.Identifier;
}
