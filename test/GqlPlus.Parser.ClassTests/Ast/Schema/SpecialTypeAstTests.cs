namespace GqlPlus.Ast.Schema;

public class SpecialTypeAstTests
  : AstAliasedBaseTests
{
  internal override IAstAliasedChecks<string> AliasedChecks { get; }
    = new SpecialTypeAstChecks();
}

internal sealed class SpecialTypeAstChecks()
  : AstAliasedChecks<SpecialTypeAst>(CreateSpecial)
{
  protected override string AliasesString(string input, string description, string aliases)
    => $"( {DescriptionNameString("_" + input, description)}{SpecialTypeAliases(input, aliases)} )";

  private static string SpecialTypeAliases(string input, string aliases)
    => string.IsNullOrWhiteSpace(aliases) ? $" [ {input} ]" : aliases;

  private static SpecialTypeAst CloneSpecial(SpecialTypeAst original, string input)
    => original with { Name = "_" + input };
  private static SpecialTypeAst CreateSpecial(string input)
    => new(input);
}
