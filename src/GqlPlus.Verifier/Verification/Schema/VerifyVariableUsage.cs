using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyVariableUsage(
    IVerify<ArgumentAst> usage,
    IVerify<VariableAst> definition
) : UsageNamedVerifier<ArgumentAst, VariableAst>(usage, definition)
{
  public override string Label => "Variable";

  public override string UsageKey(ArgumentAst item) => item.Variable!;
}
