﻿namespace GqlPlus.Verifier.Ast.Schema.Objects;

public class DualFieldAstTests
  : AstFieldTests<DualFieldAst, DualReferenceAst>
{
  protected override string AliasesString(FieldInput input, string aliases)
    => $"( !DF {input.Name}{aliases} : {input.Type} )";

  private readonly AstFieldChecks<DualFieldAst, DualReferenceAst> _checks = new(
      (dual, reference) => new(AstNulls.At, dual.Name, reference),
      dual => new(AstNulls.At, dual.Type),
      arguments => arguments.DualReferences());

  internal override IAstFieldChecks<DualFieldAst, DualReferenceAst> FieldChecks => _checks;
}
