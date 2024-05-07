using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyFragmentUsage(
    IVerify<IGqlpSpread> usage,
    IVerify<IGqlpFragment> definition
) : NamedVerifier<IGqlpSpread, IGqlpFragment>(usage, definition)
{
  public override string Label => "Spread";

  public override string UsageKey(IGqlpSpread item) => item.Name;
}
