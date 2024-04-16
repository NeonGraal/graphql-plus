namespace GqlPlus.Verifier.Ast.Schema.Types;

public class UnionMemberAstTests
  : AstAbbreviatedTests
{
  private readonly AstAbbreviatedChecks<UnionMemberAst> _checks
    = new(name => new UnionMemberAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
