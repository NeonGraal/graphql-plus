using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class InputBaseModelTests(
  IInputBaseModelChecks checks
) : TestObjBaseModel<IGqlpInputBase, IGqlpInputArg, InputBaseModel>(checks)
{ }

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IEncoder<InputBaseModel> encoding
) : CheckObjBaseModel<IGqlpInputBase, IGqlpInputArg, InputBaseAst, InputArgAst, InputBaseModel>(modeller, encoding, TypeKindModel.Input)
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
