using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseCategoryTests(
  Parser<CategoryDeclAst>.D parser
) : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithOption_ReturnsCorrectAst(string output, CategoryOption option)
    => _checks.Ok(
      "{(" + option.ToString().ToLowerInvariant() + ")" + output + "}",
      new CategoryDeclAst(AstNulls.At, output) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void WithOptionBad_ReturnsFalse(string output, CategoryOption option)
    => _checks.Error(
      "{(" + option.ToString().ToLowerInvariant() + " " + output + "}",
      "')'");

  [Theory, RepeatData(Repeats)]
  public void WithOptionNone_ReturnsFalse(string output)
    => _checks.Error("{()" + output, "");

  [Theory, RepeatData(Repeats)]
  public void WithName_ReturnsCorrectAst(string output, string name)
    => _checks.Ok(
      name + "{" + output + "}",
      new CategoryDeclAst(AstNulls.At, name, output));

  [Theory, RepeatData(Repeats)]
  public void WithModifers_ReturnsCorrectAst(string output)
    => _checks.Ok(
    "{" + output + "[]?}",
      new CategoryDeclAst(AstNulls.At, output) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string output, CategoryOption option, string[] aliases)
    => _checks.Ok(
      name + aliases.Bracket("[", "]{(").Joined() + option.ToString().ToLowerInvariant() + ")" + output + "[]?}",
      new CategoryDeclAst(AstNulls.At, name, output) {
        Aliases = aliases,
        Option = option,
        Modifiers = TestMods()
      });

  internal override IBaseAliasedChecks<string> AliasChecks => _checks;

  private readonly ParseCategoryChecks _checks = new(parser);
}

internal sealed class ParseCategoryChecks(
  Parser<CategoryDeclAst>.D parser
) : BaseAliasedChecks<string, CategoryDeclAst>(parser)
{
  protected internal override CategoryDeclAst AliasedFactory(string input)
    => new(AstNulls.At, input);
  protected internal override string AliasesString(string input, string aliases)
    => aliases + "{" + input + "}";
}
