using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Modelling.Objects;

public class DualBaseModelTests(
  IModeller<DualBaseAst, DualBaseModel> modeller
) : TestObjBaseModel<DualBaseAst>
{
  internal override ICheckObjBaseModel<DualBaseAst> ObjBaseChecks => _checks;

  private readonly DualBaseModelChecks _checks = new(modeller);
}

internal sealed class DualBaseModelChecks(
  IModeller<DualBaseAst, DualBaseModel> modeller
) : CheckObjBaseModel<DualBaseAst, DualBaseModel>(modeller, TypeKindModel.Dual)
{
  protected override DualBaseAst NewObjBaseAst(string name)
    => new(AstNulls.At, name);
}
