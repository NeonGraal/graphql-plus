using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualBaseModelTests(
  IModeller<IGqlpDualBase, DualBaseModel> modeller,
  IRenderer<DualBaseModel> rendering
) : TestObjBaseModel<IGqlpDualBase, IGqlpDualArgument>
{
  internal override ICheckObjBaseModel<IGqlpDualBase, IGqlpDualArgument> ObjBaseChecks => _checks;

  private readonly DualBaseModelChecks _checks = new(modeller, rendering);
}

internal sealed class DualBaseModelChecks(
  IModeller<IGqlpDualBase, DualBaseModel> modeller,
  IRenderer<DualBaseModel> rendering
) : CheckObjBaseModel<IGqlpDualBase, IGqlpDualArgument, DualBaseAst, DualArgumentAst, DualBaseModel>(modeller, rendering, TypeKindModel.Dual)
{
  protected override DualArgumentAst NewObjArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input) {
      IsTypeParameter = isTypeParam,
    };

  protected override DualBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpDualArgument[] args)
    => new(AstNulls.At, input) {
      IsTypeParameter = isTypeParam,
      BaseArguments = args,
    };
}
