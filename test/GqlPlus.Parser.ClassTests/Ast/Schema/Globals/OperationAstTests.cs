namespace GqlPlus.Ast.Schema.Globals;

public partial class OperationDeclAstTests
{
  private readonly OperationDeclAstChecks _checks = new();

  private static OperationDeclAst CloneInput(OperationDeclAst original, OperationInput input)
    => original with { Name = input.Name };
  internal static OperationDeclAst CreateOperation(OperationInput input)
    => new(AstNulls.At, input.Name, input.Category);

  [CheckTests(Inherited = true)]
  internal IAstAliasedChecks<OperationInput> AliasedChecks => _checks;

  [CheckTests]
  internal ICloneChecks<OperationInput> CloneChecks { get; }
    = new CloneChecks<OperationInput, OperationDeclAst>(
      CreateOperation,
      (original, input) => original with { Name = input.Name });
}

internal sealed class OperationDeclAstChecks()
  : AstAliasedChecks<OperationInput, OperationDeclAst>(OperationDeclAstTests.CreateOperation)
{
  protected override string AliasesString(OperationInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} {input.Category} )";
  protected override string InputName(OperationInput input) => input.Name;

  protected override Func<OperationInput, OperationInput, bool> SameInput
    => (input1, input2) => input1.Name.Camelize() == input2.Name.Camelize();
}
