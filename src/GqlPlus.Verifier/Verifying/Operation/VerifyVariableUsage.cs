using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyVariableUsage(IVerifierRepository verifiers) : IdentifiedVerifier<IAstArg, IAstVariable>(verifiers)
{
  public override string Label => "Variable";

  public override string UsageKey(IAstArg item) => item.Variable!;
}
