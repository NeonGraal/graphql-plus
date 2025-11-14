
namespace GqlPlus.Ast.Operation;

public class SpreadAstTests
  : AstDirectivesBaseTests
{
  internal override IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<SpreadAst>(CreateSpread, CloneSpread);

  private static SpreadAst CloneSpread(SpreadAst original, string input)
    => original with { Identifier = input };
  private static SpreadAst CreateSpread(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}
