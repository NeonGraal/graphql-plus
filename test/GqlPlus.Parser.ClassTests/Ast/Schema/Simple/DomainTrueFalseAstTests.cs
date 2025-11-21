
namespace GqlPlus.Ast.Schema.Simple;

public class DomainTrueFalseAstTests
  : AstAbbreviatedBaseTests<bool>
{
  private readonly AstAbbreviatedChecks<bool, DomainTrueFalseAst> _checks
    = new(CreateTrueFalse);

  private static DomainTrueFalseAst CloneTrueFalse(DomainTrueFalseAst original, bool input)
    => original with { Value = input };
  private static DomainTrueFalseAst CreateTrueFalse(bool input)
    => new(AstNulls.At, "", false, input);

  internal override IAstAbbreviatedChecks<bool> AbbreviatedChecks => _checks;
}
