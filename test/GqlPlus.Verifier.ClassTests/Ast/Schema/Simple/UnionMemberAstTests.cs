namespace GqlPlus.Verifier.Ast.Schema.Simple;

public class UnionMemberAstTests
  : AstAbbreviatedTests
{
  private readonly AstAbbreviatedChecks<UnionMemberAst> _checks
    = new(name => new UnionMemberAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
