namespace GqlPlus.Ast.Schema.Simple;

public class DomainRangeAstTests
  : AstAbbreviatedTests<DomainRangeInput>
{
  private readonly AstAbbreviatedChecks<DomainRangeInput, DomainRangeAst> _checks
    = new(input => new DomainRangeAst(AstNulls.At, false, input.Lower, input.Upper));

  internal override IAstAbbreviatedChecks<DomainRangeInput> AbbreviatedChecks => _checks;
}
