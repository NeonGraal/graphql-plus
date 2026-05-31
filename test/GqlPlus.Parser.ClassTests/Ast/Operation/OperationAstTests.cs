namespace GqlPlus.Ast.Operation;

public partial class OperationAstTests
{
  [Theory, RepeatData]
  public void Initial_Lists_Empty(string input)
  {
    IAstOperation ast = CreateOperation(input);

    ast.ShouldSatisfyAllConditions(
      a => a.Fragments.ShouldBeEmpty(),
      a => a.Errors.ShouldBeEmpty(),
      a => a.Usages.ShouldBeEmpty(),
      a => a.Spreads.ShouldBeEmpty()
      );
  }

  [Theory, RepeatData]
  public void HashCode_WithArgument(string input, string domain, string variable)
    => _checks.HashCode(() => new OperationAst(AstNulls.At, input) {
      Domain = domain,
      Arg = new ArgAst(AstNulls.At, variable)
    });

  [Theory, RepeatData]
  public void Text_WithArgument(string input, string domain, string variable)
    => _checks.Text(
      () => new OperationAst(AstNulls.At, input) {
        Domain = domain,
        Arg = new ArgAst(AstNulls.At, variable)
      },
      $"( !g query {input} Failure {domain} ( !a ${variable} ) )");

  [Theory, RepeatData]
  public void Equality_WithArgument(string input, string domain, string variable)
    => _checks.Equality(
      () => new OperationAst(AstNulls.At, input) {
        Domain = domain,
        Arg = new ArgAst(AstNulls.At, variable)
      });

  [Theory, RepeatData]
  public void Inequality_WithArgument(string input, string domain, string variable)
    => _checks.InequalityWith(variable,
      () => new OperationAst(AstNulls.At, input) {
        Domain = domain,
        Arg = new ArgAst(AstNulls.At, variable)
      });

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
