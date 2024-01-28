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
  {
    if (!string.IsNullOrWhiteSpace(scalar.Extends)) {
      if (context.GetType(scalar.Extends, out var extends)) {
        if (extends is AstScalar extendsScalar) {
          if (extendsScalar.Kind != scalar.Kind) {
            context.AddError(scalar, "Scalar", $" Extends '{scalar.Extends}' invalid kind");
          }
        } else {
          context.AddError(scalar, "Scalar", $" Extends '{scalar.Extends}' invalid type");
        }
      } else {
        context.AddError(scalar, "Scalar", $" Extends '{scalar.Extends}' not defined");
      }
    }
  }
}

public interface IVerifyContext<TUsage>
{
  void Verify<TContext>(TUsage usage, TContext context)
    where TContext : UsageContext;
}
