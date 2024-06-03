using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualFieldModelTests(
  IModeller<IGqlpDualField, DualFieldModel> modeller
) : TestObjectFieldModel<IGqlpDualField, DualFieldAst, IGqlpDualBase>
{
  internal override ICheckObjectFieldModel<DualFieldAst, IGqlpDualBase> FieldChecks => _checks;

  private readonly DualFieldModelChecks _checks = new(modeller);
}

internal sealed class DualFieldModelChecks(
  IModeller<IGqlpDualField, DualFieldModel> modeller
) : CheckObjectFieldModel<IGqlpDualField, DualFieldAst, IGqlpDualBase, DualFieldModel>(modeller, TypeKindModel.Dual)
{
  protected override DualFieldAst NewFieldAst(FieldInput input)
    => new(AstNulls.At, input.Name, new DualBaseAst(AstNulls.At, input.Type));
}
