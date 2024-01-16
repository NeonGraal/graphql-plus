namespace GqlPlus.Verifier.Ast.Schema;

public class EnumMemberAstTests : AstAliasedTests
{
  private readonly AstAliasedChecks<EnumMemberAst> _checks
    = new(name => new EnumMemberAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;
}
