using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Verification;

internal class VariablesContext : VerificationContext
{
  internal VariableAst[] Variables { get; }

  public VariablesContext(VerificationContext context, VariableAst[] variables)
  {
    Errors = context.Errors;
    Variables = variables;
  }
}
