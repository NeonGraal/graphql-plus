
namespace GqlPlus.Ast.Operation;

public class OperationAstTests : AstDirectivesTests
{
  internal override IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<OperationAst>(CreateOperation, CloneOperation);

  private static OperationAst CloneOperation(OperationAst original, string input)
    => original with { Identifier = input };
  private static OperationAst CreateOperation(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };

  protected override string DirectiveString(string input, string directives)
    => $"( !g query {input} Failure{directives} )";
}
