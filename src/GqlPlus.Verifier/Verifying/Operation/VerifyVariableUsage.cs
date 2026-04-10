using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyVariableUsage(IVerifierRepository verifiers) : IdentifiedVerifier<IGqlpArg, IAstVariable>(verifiers)
{
  public override string Label => "Variable";

  public override string UsageKey(IGqlpArg item) => item.Variable!;
}
