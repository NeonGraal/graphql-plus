using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseCategoryTests
  : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithOption_ReturnsCorrectAst(string output, CategoryOption option)
    => Test.TrueExpected(
      "=(" + option.ToString().ToLowerInvariant() + ")" + output,
      new CategoryAst(AstNulls.At, output) { Option = option });

  [Theory, RepeatData(Repeats)]
  public void WithOptionBad_ReturnsFalse(string output, CategoryOption option)
    => Test.False("=(" + option.ToString().ToLowerInvariant() + " " + output);

  [Theory, RepeatData(Repeats)]
  public void WithOptionNone_ReturnsFalse(string output)
    => Test.False("=()" + output);

  [Theory, RepeatData(Repeats)]
  public void WithName_ReturnsCorrectAst(string output, string name)
    => Test.TrueExpected(
      name + "=" + output,
      new CategoryAst(AstNulls.At, name, output));

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string name, string output, CategoryOption option, string[] aliases)
    => Test.TrueExpected(
      name + aliases.Bracket("[", "]=(").Joined() + option.ToString().ToLowerInvariant() + ")" + output,
      new CategoryAst(AstNulls.At, name, output) {
        Option = option,
        Aliases = aliases,
      });

  private static ParseCategoryChecks Test => new();

  internal override IBaseAliasedChecks<string> AliasChecks => Test;
}
