namespace GqlPlus.Ast.Schema.Simple;

public class DomainMemberAstTests
  : AstAbbreviatedTests
{
  private readonly AstAbbreviatedChecks<DomainMemberAst> _checks
    = new(member => new DomainMemberAst(AstNulls.At, false, member));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
