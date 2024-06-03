using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputBaseModelTests(
  IModeller<IGqlpInputBase, InputBaseModel> modeller
) : TestObjBaseModel<IGqlpInputBase, InputBaseAst>
{
  internal override ICheckObjBaseModel<InputBaseAst> ObjBaseChecks => _checks;

  private readonly InputBaseModelChecks _checks = new(modeller);
}

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, InputBaseModel> modeller
) : CheckObjBaseModel<IGqlpInputBase, InputBaseAst, InputBaseModel>(modeller, TypeKindModel.Input)
{
  protected override InputBaseAst NewObjBaseAst(string name)
    => new(AstNulls.At, name);
}
