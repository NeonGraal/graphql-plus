namespace GqlPlus.Ast.Schema.Objects;

public class DualFieldAstTests
  : AstObjectFieldTests<DualFieldAst, DualBaseAst>
{
  protected override string AliasesString(FieldInput input, string aliases)
    => $"( !DF {input.Name}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<DualFieldAst, DualBaseAst> _checks = new(
      (dual, objBase) => new(AstNulls.At, dual.Name, objBase),
      dual => new(AstNulls.At, dual.Type),
      arguments => arguments.DualBases());

  internal override IAstObjectFieldChecks<DualFieldAst, DualBaseAst> FieldChecks => _checks;
}
