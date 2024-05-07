using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputBaseModelTests(
  IModeller<InputBaseAst, InputBaseModel> modeller
) : TestObjBaseModel<InputBaseAst>
{
  internal override ICheckObjBaseModel<InputBaseAst> ObjBaseChecks => _checks;

  private readonly InputBaseModelChecks _checks = new(modeller);
}

internal sealed class InputBaseModelChecks(
  IModeller<InputBaseAst, InputBaseModel> modeller
) : CheckObjBaseModel<InputBaseAst, InputBaseModel>(modeller, TypeKindModel.Input)
{
  protected override InputBaseAst NewObjBaseAst(string name)
    => new(AstNulls.At, name);
}
