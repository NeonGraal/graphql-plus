using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualBaseModelTests(
  IModeller<IGqlpDualBase, DualBaseModel> modeller
) : TestObjBaseModel<IGqlpDualBase, DualBaseAst>
{
  internal override ICheckObjBaseModel<DualBaseAst> ObjBaseChecks => _checks;

  private readonly DualBaseModelChecks _checks = new(modeller);
}

internal sealed class DualBaseModelChecks(
  IModeller<IGqlpDualBase, DualBaseModel> modeller
) : CheckObjBaseModel<IGqlpDualBase, DualBaseAst, DualBaseModel>(modeller, TypeKindModel.Dual)
{
  protected override DualBaseAst NewObjBaseAst(string name)
    => new(AstNulls.At, name);
}
