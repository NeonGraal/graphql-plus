namespace GqlPlus.Ast.Schema.Simple;

public class DomainTrueFalseAstTests
  : AstAbbreviatedTests<bool>
{
  private readonly AstAbbreviatedChecks<bool, DomainTrueFalseAst> _checks
    = new(input => new DomainTrueFalseAst(AstNulls.At, false, input));

  internal override IAstAbbreviatedChecks<bool> AbbreviatedChecks => _checks;
}
