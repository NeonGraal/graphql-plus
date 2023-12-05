using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOperation(
  IVerifyUsage<ArgumentAst, VariableAst> usages,
  IVerifyUsage<SpreadAst, FragmentAst> spreads
) : IVerify<OperationAst>
{
  public IEnumerable<TokenMessage> Verify(OperationAst target)
  {
    var errors = new List<TokenMessage>();

    errors.AddRange(usages.Verify(new(target.Usages, target.Variables)));
    errors.AddRange(spreads.Verify(new(target.Spreads, target.Fragments)));

    return errors.Union(target.Errors);
  }
}
