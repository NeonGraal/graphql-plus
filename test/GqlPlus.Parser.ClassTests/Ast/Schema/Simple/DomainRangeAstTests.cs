
namespace GqlPlus.Ast.Schema.Simple;

public class DomainRangeAstTests
  : AstAbbreviatedBaseTests<DomainRangeInput>
{
  private readonly AstAbbreviatedChecks<DomainRangeInput, DomainRangeAst> _checks
    = new(CreateRange);

  private static DomainRangeAst CloneRange(DomainRangeAst original, DomainRangeInput input)
    => original with { Lower = input.Lower, Upper = input.Upper };
  private static DomainRangeAst CreateRange(DomainRangeInput input)
    => new(AstNulls.At, "", false, input.Lower, input.Upper);

  internal override IAstAbbreviatedChecks<DomainRangeInput> AbbreviatedChecks => _checks;
}
