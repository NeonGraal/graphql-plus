using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyVariableUsage(
    IVerify<IGqlpArg> usage,
    IVerify<IGqlpVariable> definition
) : IdentifiedVerifier<IGqlpArg, IGqlpVariable>(usage, definition)
{
  public override string Label => "Variable";

  public override string UsageKey(IGqlpArg item) => item.Variable!;
}
