using GqlPlus.Ast;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Operation;

public class SpreadAstTests : AstDirectivesTests
{
  internal override IAstDirectivesChecks DirectivesChecks { get; }
    = new AstDirectivesChecks<SpreadAst>(name => new SpreadAst(AstNulls.At, name));
}
