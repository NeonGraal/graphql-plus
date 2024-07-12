using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parsing.Schema.Globals;

public sealed class ParseOptionTests(
  IBaseAliasedChecks<string, IGqlpSchemaOption> checks
) : BaseAliasedTests<string, IGqlpSchemaOption>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithSettings_ReturnsCorrectAst(string name)
    => checks.TrueExpected(
      name + "{setting='setting'}",
      new OptionDeclAst(AstNulls.At, name) {
        Settings = s_settings.OptionSettings(),
      });

  [Theory, RepeatData(Repeats)]
  public void WithSettingsBad_ReturnsFalse(string name)
    => checks.FalseExpected(name + "{random}");

  [Theory, RepeatData(Repeats)]
  public void WithSettingsNone_ReturnsTrue(string name)
    => checks.TrueExpected(name + "{}", new OptionDeclAst(AstNulls.At, name));

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
