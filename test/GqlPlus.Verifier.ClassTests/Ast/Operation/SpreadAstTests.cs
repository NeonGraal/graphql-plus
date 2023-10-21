namespace GqlPlus.Verifier.Ast.Operation;

public class SpreadAstTests : BaseDirectivesAstTests
{
  internal override IBaseDirectivesAstChecks DirectivesChecks { get; }
    = new BaseDirectivesAstChecks<SpreadAst>(name => new SpreadAst(AstNulls.At, name));
}
