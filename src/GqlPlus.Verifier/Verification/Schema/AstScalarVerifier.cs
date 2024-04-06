using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class AstScalarVerifier<TMember>(
  IMerge<TMember> members
) : IVerifyScalar
  where TMember : AstBase, IAstScalarItem
{
  public ITokenMessages CanMergeItems(AstScalar usage, EnumContext context)
  {
    return usage is not AstScalar<TMember> scalar
|| !context.GetType(scalar.Parent, out var type)
      || type is not AstScalar<TMember> scalarParent
      ? new TokenMessages()
      : CanMergeScalar(scalar, scalarParent, context);
  }

  public void Verify(AstScalar usage, EnumContext context)
  {
    if (usage is AstScalar<TMember> scalar) {
      VerifyScalar(scalar, context);
    }
  }

  protected virtual void VerifyScalar(AstScalar<TMember> scalar, EnumContext context)
  { }

  protected virtual ITokenMessages CanMergeScalar(AstScalar<TMember> scalar, AstScalar<TMember> scalarParent, EnumContext context)
    => members.CanMerge(scalarParent.Items.Concat(scalar.Items));
}

public interface IVerifyScalar
{
  void Verify(AstScalar usage, EnumContext context);
  ITokenMessages CanMergeItems(AstScalar usage, EnumContext context);
}
