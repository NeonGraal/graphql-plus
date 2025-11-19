namespace GqlPlus.Ast.Operation;

public partial class SpreadAstTests
{
  [CheckTests]
  internal IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<SpreadAst>(CreateSpread);

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; } = new CloneChecks<string, SpreadAst>(
    CreateSpread,
    (original, input) => original with { Identifier = input });

  private static SpreadAst CreateSpread(string input)
    => new(AstNulls.At, input);
  private static SpreadAst CreateSpread(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}
