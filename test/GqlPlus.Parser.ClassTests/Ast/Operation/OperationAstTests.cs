namespace GqlPlus.Ast.Operation;

public class OperationAstTests : AstDirectivesTests
{
  internal override IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<OperationAst>(Operation);

  private static OperationAst Operation(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };

  protected override string DirectiveString(string input, string directives)
    => $"( !g query {input} Failure{directives} )";
}
