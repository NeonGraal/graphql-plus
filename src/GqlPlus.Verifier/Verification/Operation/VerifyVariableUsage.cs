using GqlPlus.Ast.Operation;

namespace GqlPlus.Verification.Operation;

internal class VerifyVariableUsage(
    IVerify<ArgumentAst> usage,
    IVerify<VariableAst> definition
) : NamedVerifier<ArgumentAst, VariableAst>(usage, definition)
{
  public override string Label => "Variable";

  public override string UsageKey(ArgumentAst item) => item.Variable!;
}
