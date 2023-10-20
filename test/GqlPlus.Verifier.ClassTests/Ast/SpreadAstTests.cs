namespace GqlPlus.Verifier.Ast;

public class SpreadAstTests : BaseNamedDirectivesAstTests
{
  internal override BaseNamedDirectivesAstChecks DirectivesChecks { get; }
    = new BaseNamedDirectivesAstChecks<SpreadAst>(name => new SpreadAst(AstNulls.At, name));
}
