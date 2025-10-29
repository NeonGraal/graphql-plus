namespace GqlPlus.Ast.Schema.Globals;

public class OperationAstTests
  : AstAliasedTests<OperationInput>
{

  protected override string AliasesString(OperationInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} {input.Category} )";
  protected override string InputName(OperationInput input) => input.Name;

  private readonly AstAliasedChecks<OperationInput, OperationDeclAst> _checks
    = new(input => new OperationDeclAst(AstNulls.At, input.Name, input.Category));

  internal override IAstAliasedChecks<OperationInput> AliasedChecks => _checks;

  protected override Func<OperationInput, OperationInput, bool> SameInput
    => (input1, input2) => input1.Name.Camelize() == input2.Name.Camelize();
}
