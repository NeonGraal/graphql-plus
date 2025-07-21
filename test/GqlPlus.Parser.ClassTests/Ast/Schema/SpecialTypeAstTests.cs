namespace GqlPlus.Ast.Schema;

public class SpecialTypeAstTests
  : AstAliasedTests
{
  internal override IAstAliasedChecks<string> AliasedChecks { get; }
    = new AstAliasedChecks<SpecialTypeAst>(name => new SpecialTypeAst(name, t => false));

  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString("_" + input, description)}{SpecialTypeAstTests.SpecialTypeAliases(input, aliases)} )";

  protected static string SpecialTypeAliases(string input, string aliases)
    => aliases.IsWhiteSpace() ? $" [ {input} ]" : aliases;
}
