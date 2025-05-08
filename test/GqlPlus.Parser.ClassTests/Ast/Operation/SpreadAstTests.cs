namespace GqlPlus.Ast.Operation;

public class SpreadAstTests : AstDirectivesTests
{
  internal override IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<SpreadAst>(Spread);

  private static SpreadAst Spread(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}
