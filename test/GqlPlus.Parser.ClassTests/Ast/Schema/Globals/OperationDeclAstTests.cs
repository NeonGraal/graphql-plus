using GqlPlus.Ast.Operation;

namespace GqlPlus.Ast.Schema.Globals;

public partial class OperationDeclAstTests
{
  [Theory, RepeatData]
  public void HashCode_WithArgument(OperationInput input, string domain, string variable)
    => _checks.HashCode(() => CreateOperation(input) with {
      Domain = new TypeRefAst(AstNulls.At, domain),
      Argument = new ArgAst(AstNulls.At, variable)
    });

  [Theory, RepeatData]
  public void Text_WithArgument(OperationInput input, string domain, string variable)
    => _checks.Text(
      () => CreateOperation(input) with {
        Domain = new TypeRefAst(AstNulls.At, domain),
        Argument = new ArgAst(AstNulls.At, variable)
      },
      $"( !SO {input.Name} {input.Category} !Tr {domain} ( !a ${variable} ) )");

  [Theory, RepeatData]
  public void Equality_WithArgument(OperationInput input, string domain, string variable)
    => _checks.Equality(
      () => CreateOperation(input) with {
        Domain = new TypeRefAst(AstNulls.At, domain),
        Argument = new ArgAst(AstNulls.At, variable)
      });

  [Theory, RepeatData]
  public void Inequality_WithArgument(OperationInput input, string domain, string variable)
    => _checks.InequalityWith(input,
      () => CreateOperation(input) with {
        Domain = new TypeRefAst(AstNulls.At, domain),
        Argument = new ArgAst(AstNulls.At, variable)
      });

  private readonly OperationDeclAstChecks _checks = new();

  internal static OperationDeclAst CreateOperation(OperationInput input)
    => new(AstNulls.At, input.Name, input.Category);

  [CheckTests(Inherited = true)]
  internal IAstDeclarationChecks<OperationInput> AliasedChecks => _checks;

  [CheckTests]
  internal ICloneChecks<OperationInput> CloneChecks { get; }
    = new CloneChecks<OperationInput, OperationDeclAst>(
      CreateOperation,
      (original, input) => original with { Name = input.Name });
}

internal sealed class OperationDeclAstChecks()
  : AstDeclarationChecks<OperationInput, OperationDeclAst>(OperationDeclAstTests.CreateOperation)
{
  protected override string AliasesString(OperationInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} {input.Category} )";
  protected override string InputName(OperationInput input) => input.Name;

  protected override Func<OperationInput, OperationInput, bool> SameInput
    => (input1, input2) => input1.Name.Camelize() == input2.Name.Camelize();
}
