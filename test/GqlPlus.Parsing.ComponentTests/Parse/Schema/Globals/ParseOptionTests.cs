﻿using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Parse.Schema.Globals;

public sealed class ParseOptionTests(
  Parser<OptionDeclAst>.D parser
) : TestAliased<string>
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

  internal override ICheckAliased<string> AliasChecks => _checks;

  private readonly ParseOptionChecks _checks = new(parser);
  private static readonly string[] s_settings = ["setting"];
}

internal sealed class ParseOptionChecks
  : CheckAliased<string, OptionDeclAst>
{
  public ParseOptionChecks(Parser<OptionDeclAst>.D parser)
    : base(parser) { }

  internal static readonly string[] Settings = ["setting"];

  protected internal override OptionDeclAst NamedFactory(string input)
    => new(AstNulls.At, input) { Settings = Settings.OptionSettings() };

  protected internal override string AliasesString(string input, string aliases)
    => input + aliases + "{setting='setting'}";
}
