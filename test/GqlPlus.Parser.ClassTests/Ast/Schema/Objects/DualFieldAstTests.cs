﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualFieldAstTests
  : AstObjectFieldTests<IGqlpDualBase>
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<DualFieldAst, IGqlpDualBase, DualBaseAst, DualArgAst> _checks = new(
      (dual, objBase) => new(AstNulls.At, dual.Name, objBase),
      dual => new DualBaseAst(AstNulls.At, dual.Type),
      arguments => arguments.DualArgs());

  internal override IAstObjectFieldChecks<IGqlpDualBase> FieldChecks => _checks;
}
