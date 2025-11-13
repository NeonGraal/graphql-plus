
namespace GqlPlus.Ast.Schema;

public class SpecialTypeAstTests
  : AstAliasedTests
{
  internal override IAstAliasedChecks<string> AliasedChecks { get; }
    = new AstAliasedChecks<SpecialTypeAst>(CreateSpecial, CloneSpecial);

  private static SpecialTypeAst CloneSpecial(SpecialTypeAst original, string input)
    => original with { Name = "_" + input };
  private static SpecialTypeAst CreateSpecial(string input)
    => new(input);
  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString("_" + input, description)}{SpecialTypeAliases(input, aliases)} )";

  protected static string SpecialTypeAliases(string input, string aliases)
    => string.IsNullOrWhiteSpace(aliases) ? $" [ {input} ]" : aliases;
}
