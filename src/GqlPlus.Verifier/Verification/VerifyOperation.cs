using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOperation(IVerify<ArgumentAst[]> usages, IVerify<SpreadAst[]> spreads) : IVerify<OperationAst>
{
  private readonly IVerify<ArgumentAst[]> _usages = usages;
  private readonly IVerify<SpreadAst[]> _spreads = spreads;

  public bool Verify<TContext>(TContext context, OperationAst target)
    where TContext : VerificationContext
  {
    if (!_usages.Verify(new VariablesContext(context, target.Variables), target.Usages)) {

    }

    if (!_spreads.Verify(new FragmentsContext(context, target.Fragments), target.Spreads)) {

    }

    target.Errors = [.. context.Errors];

    return target.Result == ParseResultKind.Success && !target.Errors.Any();
  }
}
