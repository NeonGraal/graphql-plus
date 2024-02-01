using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification.Schema;

internal class AstScalarVerifier<TMember>
  : IVerifyScalar
  where TMember : IAstScalarItem
{
  public void Verify(AstScalar usage, EnumContext context)
  {
    if (usage is AstScalar<TMember> scalar) {
      VerifyScalar(scalar, context);
    }
  }

  protected virtual void VerifyScalar(AstScalar<TMember> scalar, EnumContext context)
  { }
}

public interface IVerifyScalar
{
  void Verify(AstScalar usage, EnumContext context);
}
