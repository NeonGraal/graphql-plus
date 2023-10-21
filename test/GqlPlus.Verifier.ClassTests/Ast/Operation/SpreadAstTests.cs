namespace GqlPlus.Verifier.Ast.Operation;

public class SpreadAstTests : BaseNamedDirectivesAstTests
{
  internal override IBaseNamedDirectivesAstChecks DirectivesChecks { get; }
    = new BaseNamedDirectivesAstChecks<SpreadAst>(name => new SpreadAst(AstNulls.At, name));
}
