using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class DomainLabelAstTests
  : AstAbbreviatedTests
{
  private readonly AstAbbreviatedChecks<DomainLabelAst> _checks
    = new(member => new DomainLabelAst(AstNulls.At, "", false, member));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
