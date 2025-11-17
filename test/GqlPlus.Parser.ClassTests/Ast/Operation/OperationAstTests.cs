namespace GqlPlus.Ast.Operation;

public partial class OperationAstTests
{
  [CheckTests(Inherited = true)]
  internal IAstDirectivesChecks DirectivesChecks { get; } = new OperationAstChecks();

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
