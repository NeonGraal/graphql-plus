using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parser.Schema.Globals;

public sealed class ParseOptionTests(
  IBaseAliasedChecks<string, IAstSchemaOption> checks
) : BaseAliasedTests<string, IAstSchemaOption>(checks)
{
  [Theory, RepeatData]
  public void WithSettings_ReturnsCorrectAst(string name)
    => checks.TrueExpected(
      name + "{setting='setting'}",
      new OptionDeclAst(AstNulls.At, name) {
        Settings = s_settings.OptionSettings(),
      });

  [Theory, RepeatData]
  public void WithSettingsBad_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{random}");

  [Theory, RepeatData]
  public void WithSettingsNone_ReturnsTrue(string name)
    => checks.TrueExpected(name + "{}", new OptionDeclAst(AstNulls.At, name));

  private static readonly string[] s_settings = ["setting"];
}

internal sealed class ParseOptionChecks(
  IParserRepository parsers
) : BaseAliasedChecks<string, OptionDeclAst, IAstSchemaOption>(parsers)
{
  internal static readonly string[] Settings = ["setting"];

  protected internal override OptionDeclAst NamedFactory(string input)
    => new(AstNulls.At, input) { Settings = Settings.OptionSettings() };

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{setting='setting'}";
}
