using GqlPlus.Ast.Schema;

namespace GqlPlus.Schema;

public class SpecialTypeAstTests
  : AstAliasedTests
{
  internal override IAstAliasedChecks<string> AliasedChecks { get; }
    = new AstAliasedChecks<SpecialTypeAst>(name => new SpecialTypeAst(name));

  protected override string AliasesString(string input, string aliases)
    => $"( !TZ _{input}{aliases} )";
}
