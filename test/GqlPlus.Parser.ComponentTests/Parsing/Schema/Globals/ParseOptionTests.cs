using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parsing.Schema.Globals;

public sealed class ParseOptionTests(
  Parser<IGqlpSchemaOption>.D parser
) : BaseAliasedTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void WithSettings_ReturnsCorrectAst(string name)
    => _checks.TrueExpected(
      name + "{setting='setting'}",
      new OptionDeclAst(AstNulls.At, name) {
        Settings = s_settings.OptionSettings(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithSettingsBad_ReturnsFalse(string name)
    => _checks.False(name + "{random}");

  [Theory, RepeatData(Repeats)]
  public void WithSettingsNone_ReturnsTrue(string name)
    => _checks.TrueExpected(name + "{}", new OptionDeclAst(AstNulls.At, name));

  internal override IBaseAliasedChecks<string> AliasChecks => _checks;

  private readonly ParseOptionChecks _checks = new(parser);
  private static readonly string[] s_settings = ["setting"];
}

internal sealed class ParseOptionChecks(
  Parser<IGqlpSchemaOption>.D parser
) : BaseAliasedChecks<string, OptionDeclAst, IGqlpSchemaOption>(parser)
{
  internal static readonly string[] Settings = ["setting"];

  protected internal override OptionDeclAst NamedFactory(string input)
    => new(AstNulls.At, input) { Settings = Settings.OptionSettings() };

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{setting='setting'}";
}
