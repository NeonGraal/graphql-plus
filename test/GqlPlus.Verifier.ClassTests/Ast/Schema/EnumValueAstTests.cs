namespace GqlPlus.Verifier.Ast.Schema;

public class EnumValueAstTests : AstAliasedTests
{
  private readonly AstAliasedChecks<EnumValueAst> _checks
    = new(name => new EnumValueAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;
}
