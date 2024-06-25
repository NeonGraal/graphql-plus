using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualFieldModelTests(
  IModeller<IGqlpDualField, DualFieldModel> modeller,
  IRenderer<DualFieldModel> rendering
) : TestObjectFieldModel<IGqlpDualField, IGqlpDualBase>
{
  internal override ICheckObjectFieldModel<IGqlpDualField> FieldChecks => _checks;

  private readonly DualFieldModelChecks _checks = new(modeller, rendering);
}

internal sealed class DualFieldModelChecks(
  IModeller<IGqlpDualField, DualFieldModel> modeller,
  IRenderer<DualFieldModel> rendering
) : CheckObjectFieldModel<IGqlpDualField, DualFieldAst, IGqlpDualBase, DualFieldModel>(modeller, rendering, TypeKindModel.Dual)
{
  internal override DualFieldAst NewFieldAst(FieldInput input, string[] aliases, bool withModifiers)
    => new(AstNulls.At, input.Name, new DualBaseAst(AstNulls.At, input.Type)) {
      Aliases = aliases,
      Modifiers = withModifiers ? TestMods() : [],
    };
}
