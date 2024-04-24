namespace GqlPlus.Verifier.Ast.Schema;

public class SpecialTypeAstTests : AstAliasedTests
{
  internal override IAstAliasedChecks<string> AliasedChecks { get; }
    = new AstAliasedChecks<SpecialTypeAst>(name => new SpecialTypeAst(AstNulls.At, name));

  protected override string AliasesString(string input, string aliases)
    => $"( !TZ _{input}{aliases} )";
}
