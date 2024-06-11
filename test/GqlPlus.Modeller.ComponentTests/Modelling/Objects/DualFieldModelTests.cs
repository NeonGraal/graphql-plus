using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualFieldModelTests(
  IModeller<IGqlpDualField, DualFieldModel> modeller,
  IRenderer<DualFieldModel> rendering
) : TestObjectFieldModel<IGqlpDualField, DualFieldAst, IGqlpDualBase>
{
  internal override ICheckObjectFieldModel<DualFieldAst, IGqlpDualBase> FieldChecks => _checks;

  private readonly DualFieldModelChecks _checks = new(modeller, rendering);
}

internal sealed class DualFieldModelChecks(
  IModeller<IGqlpDualField, DualFieldModel> modeller,
  IRenderer<DualFieldModel> rendering
) : CheckObjectFieldModel<IGqlpDualField, DualFieldAst, IGqlpDualBase, DualFieldModel>(modeller, rendering, TypeKindModel.Dual)
{
  protected override DualFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, new DualBaseAst(AstNulls.At, input.Type));
}
