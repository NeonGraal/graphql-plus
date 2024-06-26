using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualBaseModelTests(
  IModeller<IGqlpDualBase, DualBaseModel> modeller,
  IRenderer<DualBaseModel> rendering
) : TestObjBaseModel<IGqlpDualBase>
{
  internal override ICheckObjBaseModel<IGqlpDualBase> ObjBaseChecks => _checks;

  private readonly DualBaseModelChecks _checks = new(modeller, rendering);
}

internal sealed class DualBaseModelChecks(
  IModeller<IGqlpDualBase, DualBaseModel> modeller,
  IRenderer<DualBaseModel> rendering
) : CheckObjBaseModel<IGqlpDualBase, DualBaseAst, DualBaseModel>(modeller, rendering, TypeKindModel.Dual)
{
  protected override DualBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpDualBase[] args)
    => new(AstNulls.At, input) {
      IsTypeParameter = isTypeParam,
      BaseArguments = args,
    };
}
