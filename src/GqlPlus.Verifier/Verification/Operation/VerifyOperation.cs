using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Operation;

internal class VerifyOperation(
  IVerifyUsageNamed<ArgumentAst, VariableAst> usages,
  IVerifyUsageNamed<SpreadAst, FragmentAst> spreads
) : IVerify<OperationAst>
{
  public void Verify(OperationAst item, ITokenMessages errors)
  {
    usages.Verify(new(item.Usages, item.Variables), errors);
    spreads.Verify(new(item.Spreads, item.Fragments), errors);

    errors.Add(item.Errors);
  }
}
