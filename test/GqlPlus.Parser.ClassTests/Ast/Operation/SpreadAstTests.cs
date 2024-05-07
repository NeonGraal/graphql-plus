namespace GqlPlus.Ast.Operation;

public class SpreadAstTests : AstDirectivesTests
{
  internal override IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<SpreadAst>(name => new SpreadAst(AstNulls.At, name));
}
