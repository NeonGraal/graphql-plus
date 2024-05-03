using GqlPlus.Ast.Operation;
using GqlPlus.Token;

namespace GqlPlus.Verification.Operation;

internal class VerifyOperation(
  IVerifyNamed<ArgumentAst, VariableAst> usages,
  IVerifyNamed<SpreadAst, FragmentAst> spreads
) : IVerify<OperationAst>
{
  public void Verify(OperationAst item, ITokenMessages errors)
  {
    usages.Verify(new(item.Usages, item.Variables), errors);
    spreads.Verify(new(item.Spreads, item.Fragments), errors);

    errors.Add(item.Errors);
  }
}
