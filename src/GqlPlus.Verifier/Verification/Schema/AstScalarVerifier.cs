using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;

namespace GqlPlus.Verifier.Verification.Schema;

internal class AstScalarVerifier<TMember>(
  IMerge<TMember> members
) : IVerifyScalar
  where TMember : IAstScalarItem
{
  public bool CanMergeItems(AstScalar usage, EnumContext context)
  {
    return usage is not AstScalar<TMember> scalar
|| !context.GetType(scalar.Parent, out var type)
      || type is not AstScalar<TMember> scalarParent
|| CanMergeScalar(scalar, scalarParent, context);
  }

  public void Verify(AstScalar usage, EnumContext context)
  {
    if (usage is AstScalar<TMember> scalar) {
      VerifyScalar(scalar, context);
    }
  }

  protected virtual void VerifyScalar(AstScalar<TMember> scalar, EnumContext context)
  { }

  protected virtual bool CanMergeScalar(AstScalar<TMember> scalar, AstScalar<TMember> scalarParent, EnumContext context)
    => members.CanMerge(scalarParent.Items.Concat(scalar.Items));
}

public interface IVerifyScalar
{
  void Verify(AstScalar usage, EnumContext context);
  bool CanMergeItems(AstScalar usage, EnumContext context);
}
