using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputBaseModelTests(
  IInputBaseModelChecks checks
) : TestObjBaseModel<IGqlpInputBase, IGqlpInputArg, InputBaseModel>(checks)
{ }

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IRenderer<InputBaseModel> rendering
) : CheckObjBaseModel<IGqlpInputBase, IGqlpInputArg, InputBaseAst, InputArgAst, InputBaseModel>(modeller, rendering, TypeKindModel.Input)
  , IInputBaseModelChecks
{
  protected override InputArgAst NewObjArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
    };

  protected override InputBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpInputArg[] args)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
      BaseArgs = args,
    };
}

public interface IInputBaseModelChecks
  : ICheckObjBaseModel<IGqlpInputBase, IGqlpInputArg, InputBaseModel>
{ }
