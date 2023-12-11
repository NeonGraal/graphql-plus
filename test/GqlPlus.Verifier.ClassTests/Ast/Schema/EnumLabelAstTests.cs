namespace GqlPlus.Verifier.Ast.Schema;

public class EnumValueAstTests : BaseAliasedAstTests
{
  private readonly BaseAliasedAstChecks<EnumValueAst> _checks
    = new(name => new EnumValueAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IBaseAliasedAstChecks<string> AliasedChecks => _checks;
}
