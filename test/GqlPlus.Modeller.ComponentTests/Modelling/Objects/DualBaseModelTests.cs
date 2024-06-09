using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Objects;

public class DualBaseModelTests(
  IModeller<IGqlpDualBase, DualBaseModel> modeller,
  IRenderer<DualBaseModel> rendering
) : TestObjBaseModel<IGqlpDualBase, DualBaseAst>
{
  internal override ICheckObjBaseModel<DualBaseAst> ObjBaseChecks => _checks;

  private readonly DualBaseModelChecks _checks = new(modeller, rendering);
}

internal sealed class DualBaseModelChecks(
  IModeller<IGqlpDualBase, DualBaseModel> modeller,
  IRenderer<DualBaseModel> rendering
) : CheckObjBaseModel<IGqlpDualBase, DualBaseAst, DualBaseModel>(modeller, rendering, TypeKindModel.Dual)
{
  protected override DualBaseAst NewObjBaseAst(string name)
    => new(AstNulls.At, name);
}
