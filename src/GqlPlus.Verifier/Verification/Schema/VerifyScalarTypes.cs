using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyScalarTypes(
  IVerifyAliased<AstScalar> aliased,
  IEnumerable<IVerifyContext<AstScalar>> scalars
) : AstTypeVerifier<AstScalar, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(AstScalar usage, IMap<AstType[]> byId, ITokenMessages errors)
    => MakeUsageContext(byId, errors);

  protected override void UsageValue(AstScalar usage, UsageContext context)
  {
    foreach (var scalar in scalars) {
      scalar.Verify(usage, context);
    }
  }
}
