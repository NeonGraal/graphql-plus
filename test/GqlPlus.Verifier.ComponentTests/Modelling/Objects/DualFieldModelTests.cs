using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Modelling.Objects;

public class DualFieldModelTests(
  IModeller<DualFieldAst, DualFieldModel> modeller
) : TestObjectFieldModel<DualFieldAst, DualBaseAst>
{
  internal override ICheckObjectFieldModel<DualFieldAst, DualBaseAst> FieldChecks => _checks;

  private readonly DualFieldModelChecks _checks = new(modeller);
}

internal sealed class DualFieldModelChecks(
  IModeller<DualFieldAst, DualFieldModel> modeller
) : CheckObjectFieldModel<DualFieldAst, DualBaseAst, DualFieldModel>(modeller, TypeKindModel.Dual)
{
  protected override DualFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, new DualBaseAst(AstNulls.At, input.Type));
}
