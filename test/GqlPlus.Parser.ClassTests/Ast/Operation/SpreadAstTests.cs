
namespace GqlPlus.Ast.Operation;

public partial class SpreadAstTests
{
  [CheckTests]
  internal IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<SpreadAst>(CreateSpread);

  private static SpreadAst CreateSpread(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}
