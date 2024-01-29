using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification.Schema;

internal class AstScalarVerifier<TMember>
  : IVerifyContext<AstScalar>
  where TMember : IAstScalarMember
{
  public void Verify<TContext>(AstScalar usage, TContext context)
    where TContext : UsageContext
  {
    if (usage is AstScalar<TMember> scalar) {
      VerifyScalar(scalar, context);
    }
  }

  protected virtual void VerifyScalar(AstScalar<TMember> scalar, UsageContext context)
  { }
}

public interface IVerifyContext<TUsage>
{
  void Verify<TContext>(TUsage usage, TContext context)
    where TContext : UsageContext;
}
