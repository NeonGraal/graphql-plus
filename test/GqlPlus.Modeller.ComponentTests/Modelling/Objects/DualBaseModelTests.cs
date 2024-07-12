using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualBaseModelTests(
  IDualBaseModelChecks checks
) : TestObjBaseModel<IGqlpDualBase, IGqlpDualArgument, DualBaseModel>(checks)
{ }

internal sealed class DualBaseModelChecks(
  IModeller<IGqlpDualBase, DualBaseModel> modeller,
  IRenderer<DualBaseModel> rendering
) : CheckObjBaseModel<IGqlpDualBase, IGqlpDualArgument, DualBaseAst, DualArgumentAst, DualBaseModel>(modeller, rendering, TypeKindModel.Dual)
  , IDualBaseModelChecks
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

public interface IDualBaseModelChecks
  : ICheckObjBaseModel<IGqlpDualBase, IGqlpDualArgument, DualBaseModel>
{ }
