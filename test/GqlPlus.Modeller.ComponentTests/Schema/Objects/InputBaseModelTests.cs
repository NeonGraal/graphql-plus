using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class InputBaseModelTests(
  IInputBaseModelChecks checks
) : TestObjBaseModel<IGqlpInputBase, IGqlpObjArg, InputBaseModel>(checks)
{ }

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, InputBaseModel> modeller,
  IEncoder<InputBaseModel> encoding
) : CheckObjBaseModel<IGqlpInputBase, IGqlpObjArg, InputBaseAst, InputArgAst, InputBaseModel>(modeller, encoding, TypeKindModel.Input)
  , IInputBaseModelChecks
{
  protected override InputArgAst NewObjArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
    };

  protected override InputBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpObjArg[] args)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
      BaseArgs = args,
    };
}

public interface IInputBaseModelChecks
  : ICheckObjBaseModel<IGqlpInputBase, IGqlpObjArg, InputBaseModel>
{ }
