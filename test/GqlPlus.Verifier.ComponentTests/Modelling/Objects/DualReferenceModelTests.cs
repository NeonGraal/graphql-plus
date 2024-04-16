using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling.Objects;

public class DualReferenceModelTests(
  IModeller<DualReferenceAst, DualBaseModel> modeller
) : TestReferenceModel<DualReferenceAst>
{
  internal override ICheckReferenceModel<DualReferenceAst> ReferenceChecks => _checks;

  private readonly DualReferenceModelChecks _checks = new(modeller);
}

internal sealed class DualReferenceModelChecks(
  IModeller<DualReferenceAst, DualBaseModel> modeller
) : CheckReferenceModel<DualReferenceAst, DualBaseModel>(modeller, TypeKindModel.Dual)
{
  protected override DualReferenceAst NewReferenceAst(string name)
    => new(AstNulls.At, name);
}
