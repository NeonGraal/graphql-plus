
namespace GqlPlus.Ast.Operation;

public class OperationAstTests
  : AstDirectivesBaseTests
{
  internal override IAstDirectivesChecks DirectivesChecks { get; }
    = new OperationAstChecks();
}

internal sealed class OperationAstChecks()
  : AstDirectivesChecks<OperationAst>(CreateOperation, CloneOperation)
{
  protected override string DirectiveString(string input, string directives)
    => $"( !g query {input} Failure{directives} )";

  private static OperationAst CloneOperation(OperationAst original, string input)
    => original with { Identifier = input };
  private static OperationAst CreateOperation(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}
