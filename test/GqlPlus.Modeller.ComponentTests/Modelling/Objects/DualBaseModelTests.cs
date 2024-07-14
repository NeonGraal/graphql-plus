﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualBaseModelTests(
  IDualBaseModelChecks checks
) : TestObjBaseModel<IGqlpDualBase, IGqlpDualArg, DualBaseModel>(checks)
{ }

internal sealed class DualBaseModelChecks(
  IModeller<IGqlpDualBase, DualBaseModel> modeller,
  IRenderer<DualBaseModel> rendering
) : CheckObjBaseModel<IGqlpDualBase, IGqlpDualArg, DualBaseAst, DualArgAst, DualBaseModel>(modeller, rendering, TypeKindModel.Dual)
  , IDualBaseModelChecks
{
  protected override DualArgAst NewObjArgAst(string input, bool isTypeParam)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
    };

  protected override DualBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpDualArg[] args)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
      BaseArgs = args,
    };
}

public interface IDualBaseModelChecks
  : ICheckObjBaseModel<IGqlpDualBase, IGqlpDualArg, DualBaseModel>
{ }
