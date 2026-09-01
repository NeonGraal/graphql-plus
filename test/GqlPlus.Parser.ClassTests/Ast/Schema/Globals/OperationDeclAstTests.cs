using GqlPlus.Ast.Operation;

namespace GqlPlus.Ast.Schema.Globals;

public partial class OperationDeclAstTests
{
  [Theory, RepeatData]
  public void Base_Lists_Empty(OperationInput input)
  {
    IAstOperationBase ast = CreateOperation(input);

    ast.ShouldSatisfyAllConditions(
      a => a.Argument.ShouldBeNull(),
      a => a.Category.ShouldBe(input.Category),
      a => a.Fragments.ShouldBeEmpty(),
      a => a.Selections.ShouldBeEmpty(),
      a => a.Variables.ShouldBeEmpty()
      );
  }

  [Theory, RepeatData]
  public void HashCode_WithArgument(OperationInput input, string domain, string variable)
    => _checks.HashCode(() => CreateOperation(input, domain, variable));

  [Theory, RepeatData]
  public void Text_WithArgument(OperationInput input, string domain, string variable)
    => _checks.Text(
      () => CreateOperation(input, domain, variable),
      $"( !SO {input.Name} {input.Category} !Tr {domain} ( !a ${variable} ) )");

  [Theory, RepeatData]
  public void Equality_WithArgument(OperationInput input, string domain, string variable)
    => _checks.Equality(() => CreateOperation(input, domain, variable));

  [Theory, RepeatData]
  public void Inequality_WithArgument(OperationInput input, string domain, string variable)
    => _checks.InequalityWith(input, () => CreateOperation(input, domain, variable));

  private readonly OperationDeclAstChecks _checks = new();

  internal static OperationDeclAst CreateOperation(OperationInput input)
    => new(AstNulls.At, input.Name, b
      => b.Category = input.Category);

  internal static OperationDeclAst CreateOperation(OperationInput input, string domain, string variable)
    => new(AstNulls.At, input.Name, b
      => {
        b.Category = input.Category;
        b.Argument = new ArgAst(AstNulls.At, variable);
      }) {
      Domain = new TypeRefAst(AstNulls.At, domain)
    };

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
