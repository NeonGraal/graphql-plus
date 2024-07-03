using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputBaseModelTests(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IRenderer<InputBaseModel> rendering
) : TestObjBaseModel<IGqlpInputBase, IGqlpInputArgument>
{
  internal override ICheckObjBaseModel<IGqlpInputBase, IGqlpInputArgument> ObjBaseChecks => _checks;

  private readonly InputBaseModelChecks _checks = new(modeller, rendering);
}

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IRenderer<InputBaseModel> rendering
) : CheckObjBaseModel<IGqlpInputBase, IGqlpInputArgument, InputBaseAst, InputArgumentAst, InputBaseModel>(modeller, rendering, TypeKindModel.Input)
{
  protected override InputArgumentAst NewObjArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input) {
      IsTypeParameter = isTypeParam,
    };

  protected override InputBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpInputArgument[] args)
    => new(AstNulls.At, input) {
      IsTypeParameter = isTypeParam,
      BaseArguments = args,
    };
}
