namespace GqlPlus.Ast.Schema.Objects;

public class DualFieldAstTests
  : AstObjectFieldTests
{
  protected override string AliasesString(FieldInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} : {input.Type} )";

  private readonly AstObjectFieldChecks<DualFieldAst> _checks = new(
      (dual, objBase) => new(AstNulls.At, dual.Name, objBase));

  internal override IAstObjectFieldChecks FieldChecks => _checks;
}
