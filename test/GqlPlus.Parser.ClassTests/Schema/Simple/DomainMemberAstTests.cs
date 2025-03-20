using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class DomainMemberAstTests
  : AstAbbreviatedTests
{
  private readonly AstAbbreviatedChecks<DomainMemberAst> _checks
    = new(member => new DomainMemberAst(AstNulls.At, "", false, member));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
