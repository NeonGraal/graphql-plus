﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Objects;

public class DualBaseModelTests(
  IDualBaseModelChecks checks
) : TestObjBaseModel<IGqlpDualBase, IGqlpObjArg, ObjBaseModel>(checks)
{ }

internal sealed class DualBaseModelChecks(
  IModeller<IGqlpDualBase, ObjBaseModel> modeller,
  IEncoder<ObjBaseModel> encoding
) : CheckObjBaseModel<IGqlpDualBase, IGqlpObjArg, DualBaseAst, DualArgAst, ObjBaseModel>(modeller, encoding, TypeKindModel.Dual)
  , IDualBaseModelChecks
{
  protected override IGqlpObjArg NewObjArgAst(string input, bool isTypeParam)
    => new DualArgAst(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
    };

  protected override DualBaseAst NewObjBaseAst(string input, bool isTypeParam, IGqlpObjArg[] args)
    => new(AstNulls.At, input) {
      IsTypeParam = isTypeParam,
      BaseArgs = args,
    };
}

public interface IDualBaseModelChecks
  : ICheckObjBaseModel<IGqlpDualBase, IGqlpObjArg, ObjBaseModel>
{ }
