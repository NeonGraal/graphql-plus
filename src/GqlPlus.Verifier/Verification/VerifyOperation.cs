using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOperation(
  IVerifyUsageNamed<ArgumentAst, VariableAst> usages,
  IVerifyUsageNamed<SpreadAst, FragmentAst> spreads
) : IVerify<OperationAst>
{
  public ITokenMessages Verify(OperationAst target)
  {
    var errors = new TokenMessages();

    errors.AddRange(usages.Verify(new(target.Usages, target.Variables)));
    errors.AddRange(spreads.Verify(new(target.Spreads, target.Fragments)));

    errors.AddRange(target.Errors);

    return errors;
  }
}
