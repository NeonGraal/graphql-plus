﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Objects;

public class DualModelTests(
  IModeller<IGqlpDualObject, TypeDualModel> modeller,
  IRenderer<TypeDualModel> rendering
) : TestObjectModel<DualDeclAst, DualFieldAst, IGqlpDualBase, DualBaseAst>
{
  internal override ICheckObjectModel<DualDeclAst, DualFieldAst, IGqlpDualBase> ObjectChecks => _checks;

  private readonly DualModelChecks _checks = new(modeller, rendering);
}

internal sealed class DualModelChecks(
  IModeller<IGqlpDualObject, TypeDualModel> modeller,
  IRenderer<TypeDualModel> rendering
) : CheckObjectModel<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualBase, TypeDualModel>(modeller, rendering, TypeKindModel.Dual)
{
  protected override DualDeclAst NewObjectAst(
    string name,
    IGqlpDualBase? parent,
    string? description,
    string[]? aliases,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description ?? "") {
      Aliases = aliases ?? [],
      Parent = (DualBaseAst?)parent,
      Fields = fields.DualFields(),
      Alternates = alternates.Alternates(NewParentAst),
    };
  internal override IGqlpDualBase NewParentAst(string input)
    => new DualBaseAst(AstNulls.At, input);
}
