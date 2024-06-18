using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputBaseModelTests(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IRenderer<InputBaseModel> rendering
) : TestObjBaseModel<IGqlpInputBase, InputBaseAst>
{
  internal override ICheckObjBaseModel<IGqlpInputBase, InputBaseAst> ObjBaseChecks => _checks;

  private readonly InputBaseModelChecks _checks = new(modeller, rendering);
}

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IRenderer<InputBaseModel> rendering
) : CheckObjBaseModel<IGqlpInputBase, InputBaseAst, InputBaseModel>(modeller, rendering, TypeKindModel.Input)
{
  protected override InputBaseAst NewObjBaseAst(string name)
    => new(AstNulls.At, name);
}
