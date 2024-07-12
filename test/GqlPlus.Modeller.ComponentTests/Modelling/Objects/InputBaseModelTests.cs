using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputBaseModelTests(
  IInputBaseModelChecks checks
) : TestObjBaseModel<IGqlpInputBase, IGqlpInputArgument, InputBaseModel>(checks)
{ }

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IRenderer<InputBaseModel> rendering
) : CheckObjBaseModel<IGqlpInputBase, IGqlpInputArgument, InputBaseAst, InputArgumentAst, InputBaseModel>(modeller, rendering, TypeKindModel.Input)
  , IInputBaseModelChecks
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

public interface IInputBaseModelChecks
  : ICheckObjBaseModel<IGqlpInputBase, IGqlpInputArgument, InputBaseModel>
{ }
