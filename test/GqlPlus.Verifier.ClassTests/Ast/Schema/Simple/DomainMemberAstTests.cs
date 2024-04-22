using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Ast.Schema.Types;

public class DomainMemberAstTests
  : AstAbbreviatedTests
{
  private readonly AstAbbreviatedChecks<DomainMemberAst> _checks
    = new(member => new DomainMemberAst(AstNulls.At, false, member));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
