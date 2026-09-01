namespace GqlPlus.Ast.Operation;

public partial class OperationAstTests
{
  [Theory, RepeatData]
  public void Initial_Lists_Empty(string input)
  {
    IAstOperation ast = CreateOperation(input);

    ast.ShouldSatisfyAllConditions(
      a => a.Argument.ShouldBeNull(),
      a => a.Errors.ShouldBeEmpty(),
      a => a.Fragments.ShouldBeEmpty(),
      a => a.Selections.ShouldBeEmpty(),
      a => a.Spreads.ShouldBeEmpty(),
      a => a.Usages.ShouldBeEmpty(),
      a => a.Variables.ShouldBeEmpty()
      );
  }

  [Theory, RepeatData]
  public void Base_Lists_Empty(string input)
  {
    IAstOperationBase ast = CreateOperation(input);

    ast.ShouldSatisfyAllConditions(
      a => a.Argument.ShouldBeNull(),
      a => a.Category.ShouldBe("query"),
      a => a.Fragments.ShouldBeEmpty(),
      a => a.Selections.ShouldBeEmpty(),
      a => a.Variables.ShouldBeEmpty()
      );
  }

  [Theory, RepeatData]
  public void HashCode_WithArgument(string input, string domain, string variable)
    => _checks.HashCode(() => CreateOperation(input, domain, variable));

  [Theory, RepeatData]
  public void Text_WithArgument(string input, string domain, string variable)
    => _checks.Text(
      () => CreateOperation(input, domain, variable),
      $"( !g query {input} Failure {domain} ( !a ${variable} ) )");

  [Theory, RepeatData]
  public void Equality_WithArgument(string input, string domain, string variable)
    => _checks.Equality(
      () => CreateOperation(input, domain, variable));

  [Theory, RepeatData]
  public void Inequality_WithArgument(string input, string domain, string variable)
    => _checks.InequalityWith(variable,
      () => CreateOperation(input, domain, variable));

  internal OperationAstChecks _checks = new();

  [CheckTests(Inherited = true)]
  internal IAstDirectivesChecks DirectivesChecks => _checks;

  [CheckTests]
  internal IModifiersChecks<string> ModifiersChecks { get; } = new OperationModifiersChecks();

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; } = new CloneChecks<string, OperationAst>(
    CreateOperation,
    (original, input) => original with { Identifier = input });

  internal static OperationAst CreateOperation(string input)
    => new(AstNulls.At, input);

  internal static OperationAst CreateOperation(string input, string domain, string variable)
  {
    OperationAst operationAst = new(AstNulls.At, input) { Domain = domain };
    operationAst._operationBase.Argument = new ArgAst(AstNulls.At, variable);
    return operationAst;
  }
}

internal sealed class OperationAstChecks()
  : AstDirectivesChecks<OperationAst>(CreateOperation)
{
  protected override string DirectiveString(string input, string directives)
    => $"( !g query {input} Failure{directives} )";

  private static OperationAst CreateOperation(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}

internal sealed class OperationModifiersChecks()
  : ModifiersChecks<string, OperationAst>(
      OperationAstTests.CreateOperation,
      ast => ast with { Modifiers = TestMods() })
{
  protected override string InputString(string input)
    => $"( !g query {input} Failure )";
}
