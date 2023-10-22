namespace GqlPlus.Verifier.Ast.Schema;

public class DirectiveAstTests : BaseAliasedAstTests
{
  protected override string InputString(string input)
    => $"( !D {input} (Unique) None )";

  protected override string AliasesString(string input, params string[] aliases)
    => $"( !D {input} [ {string.Join(" ", aliases)} ] (Unique) None )";

  private readonly BaseAliasedAstChecks<DirectiveAst> _checks
    = new(name => new DirectiveAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IBaseAliasedAstChecks<string> AliasedChecks => _checks;
}
