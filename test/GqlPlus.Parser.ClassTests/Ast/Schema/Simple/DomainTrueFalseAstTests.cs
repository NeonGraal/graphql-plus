
namespace GqlPlus.Ast.Schema.Simple;

public partial class DomainTrueFalseAstTests
{
  [CheckTests(Inherited = true)]
  private IAstAbbreviatedChecks<bool> AbbreviatedChecks { get; }
    = new AstAbbreviatedChecks<bool, DomainTrueFalseAst>(CreateTrueFalse);

  [CheckTests]
  internal ICloneChecks<bool> CloneChecks { get; }
    = new CloneChecks<bool, DomainTrueFalseAst>(CreateTrueFalse, CloneTrueFalse);

  private static DomainTrueFalseAst CloneTrueFalse(DomainTrueFalseAst original, bool input)
    => original with { Value = input };
  private static DomainTrueFalseAst CreateTrueFalse(bool input)
    => new(AstNulls.At, "", false, input);
}
