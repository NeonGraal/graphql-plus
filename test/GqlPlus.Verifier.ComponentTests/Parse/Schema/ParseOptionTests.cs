using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public sealed class ParseOptionTests(
  Parser<OptionDeclAst>.D parser
) : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithNameBad_ReturnsFalse(decimal id)
    => _test.False($"{id}{{}}");

  [Theory, RepeatData(Repeats)]
  public void WithSettings_ReturnsCorrectAst(string name)
    => _test.TrueExpected(
      name + "{setting='setting'}",
      new OptionDeclAst(AstNulls.At, name) {
        Settings = s_settings.OptionSettings(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithSettingsBad_ReturnsFalse(string name)
    => _test.False(name + "{random}");

  [Theory, RepeatData(Repeats)]
  public void WithSettingsNone_ReturnsTrue(string name)
    => _test.TrueExpected(name + "{}", new OptionDeclAst(AstNulls.At, name));

  internal override IBaseAliasedChecks<string> AliasChecks => _test;

  private readonly ParseOptionChecks _test = new(parser);
  private static readonly string[] s_settings = ["setting"];
}
