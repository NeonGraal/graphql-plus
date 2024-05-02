using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Modelling.Objects;

public class DualFieldModelTests(
  IModeller<DualFieldAst, DualFieldModel> modeller
) : TestObjectFieldModel<DualFieldAst, DualReferenceAst>
{
  internal override ICheckObjectFieldModel<DualFieldAst, DualReferenceAst> FieldChecks => _checks;

  private readonly DualFieldModelChecks _checks = new(modeller);
}

internal sealed class DualFieldModelChecks(
  IModeller<DualFieldAst, DualFieldModel> modeller
) : CheckObjectFieldModel<DualFieldAst, DualReferenceAst, DualFieldModel>(modeller, TypeKindModel.Dual)
{
  protected override DualFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, new DualReferenceAst(AstNulls.At, input.Type));
}
