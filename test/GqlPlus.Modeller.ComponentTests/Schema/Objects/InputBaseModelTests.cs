using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class InputBaseModelTests(
  IInputBaseModelChecks checks
) : TestObjBaseModel<IGqlpInputBase, ObjBaseModel>(checks)
{ }

internal sealed class InputBaseModelChecks(
  IModeller<IGqlpInputBase, ObjBaseModel> modeller,
  IEncoder<ObjBaseModel> encoding
) : CheckObjBaseModel<IGqlpInputBase, InputBaseAst, InputArgAst, ObjBaseModel>(modeller, encoding, TypeKindModel.Input)
  , IInputBaseModelChecks
{
  protected override InputArgAst NewObjArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
    };

  protected override InputBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpObjArg[] args)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
      Args = args,
    };
}

public interface IInputBaseModelChecks
  : ICheckObjBaseModel<IGqlpInputBase, ObjBaseModel>
{ }
