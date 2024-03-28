using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class DualFieldModelTests(
  IModeller<DualFieldAst, DualFieldModel> modeller
) : TestFieldModel<DualFieldAst, DualReferenceAst>
{
  internal override ICheckFieldModel<DualFieldAst, DualReferenceAst> FieldChecks => _checks;

  private readonly DualFieldModelChecks _checks = new(modeller);
}

internal sealed class DualFieldModelChecks(
  IModeller<DualFieldAst, DualFieldModel> modeller
) : CheckFieldModel<DualFieldAst, DualReferenceAst, DualFieldModel>(modeller, TypeKindModel.Dual)
{
  protected override DualFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, new DualReferenceAst(AstNulls.At, input.Type));
}
