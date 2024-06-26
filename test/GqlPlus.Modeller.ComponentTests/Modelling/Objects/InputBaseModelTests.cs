using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputBaseModelTests(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IRenderer<InputBaseModel> rendering
) : TestObjBaseModel<IGqlpInputBase>
{
  internal override ICheckObjBaseModel<IGqlpInputBase> ObjBaseChecks => _checks;

  private readonly InputBaseModelChecks _checks = new(modeller, rendering);
}

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IRenderer<InputBaseModel> rendering
) : CheckObjBaseModel<IGqlpInputBase, InputBaseAst, InputBaseModel>(modeller, rendering, TypeKindModel.Input)
{
  protected override InputBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpInputBase[] args)
    => new(AstNulls.At, input) {
      IsTypeParameter = isTypeParam,
      BaseArguments = args,
    };
}
