using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Verification;

internal class VerifyVariableUsage(
    IVerify<ArgumentAst>? usage,
    IVerify<VariableAst>? definition
) : UsageVerifier<ArgumentAst, VariableAst>(usage, definition)
{
  public override string Label => "Variable";

  public override string UsageKey(ArgumentAst item) => item.Variable!;
}
