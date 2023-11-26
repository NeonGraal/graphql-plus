using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseCategoryTests
  : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithOption_ReturnsCorrectAst(string output, CategoryOption option)
    => _test.Ok(
      "{(" + option.ToString().ToLowerInvariant() + ")" + output + "}",
      new CategoryAst(AstNulls.At, output) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void WithOptionBad_ReturnsFalse(string output, CategoryOption option)
    => _test.Error(
      "{(" + option.ToString().ToLowerInvariant() + " " + output + "}",
      "')'");

  [Theory, RepeatData(Repeats)]
  public void WithOptionNone_ReturnsFalse(string output)
    => _test.Error("{()" + output, "");

  [Theory, RepeatData(Repeats)]
  public void WithName_ReturnsCorrectAst(string output, string name)
    => _test.Ok(
      name + "{" + output + "}",
      new CategoryAst(AstNulls.At, name, output));

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string output, CategoryOption option, string[] aliases)
    => _test.Ok(
      name + aliases.Bracket("[", "]{(").Joined() + option.ToString().ToLowerInvariant() + ")" + output + "}",
      new CategoryAst(AstNulls.At, name, output) {
        Option = option,
        Aliases = aliases,
      });

  private readonly ParseCategoryChecks _test;

  internal override IBaseAliasedChecks<string> AliasChecks => _test;

  public ParseCategoryTests(IParser<CategoryAst> parser)
    => _test = new(parser);
}
