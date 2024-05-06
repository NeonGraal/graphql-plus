using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyVariableUsage(
    IVerify<IGqlpArgument> usage,
    IVerify<IGqlpVariable> definition
) : NamedVerifier<IGqlpArgument, IGqlpVariable>(usage, definition)
{
  public override string Label => "Variable";

  public override string UsageKey(IGqlpArgument item) => item.Variable!;
}
