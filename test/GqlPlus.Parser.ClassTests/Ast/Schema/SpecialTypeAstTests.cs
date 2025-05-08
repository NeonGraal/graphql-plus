namespace GqlPlus.Ast.Schema;

public class SpecialTypeAstTests
  : AstAliasedTests
{
  internal override IAstAliasedChecks<string> AliasedChecks { get; }
    = new AstAliasedChecks<SpecialTypeAst>(name => new SpecialTypeAst(name));

  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString("_" + input, description)}{aliases} )";
}
