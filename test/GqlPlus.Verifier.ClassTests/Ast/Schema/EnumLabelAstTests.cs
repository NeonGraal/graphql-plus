namespace GqlPlus.Verifier.Ast.Schema;

public class EnumLabelAstTests : BaseAliasedAstTests
{
  private readonly BaseAliasedAstChecks<EnumLabelAst> _checks
    = new(name => new EnumLabelAst(AstNulls.At, name, "")) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IBaseAliasedAstChecks<string> AliasedChecks => _checks;
}
