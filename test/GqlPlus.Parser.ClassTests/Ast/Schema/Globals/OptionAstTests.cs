namespace GqlPlus.Ast.Schema.Globals;

public class OptionAstTests
  : AstAliasedBaseTests
{
  [Theory, RepeatData]
  public void HashCode_WithSettings(string name, string[] settings)
      => _checks.HashCode(
        () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() });

  [Theory, RepeatData]
  public void Text_WithSettings(string name, string[] settings)
    => _checks.Text(
      () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() },
      $"( !Op {name} {{ {settings.Joined(s => $"!OS {s} =( !k '{s}' )")} }} )");

  [Theory, RepeatData]
  public void Equality_WithSettings(string name, string[] settings)
    => _checks.Equality(
      () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() });

  [Theory, RepeatData]
  public void Inequality_BetweenSettings(string name, string[] settings1, string[] settings2)
    => _checks.InequalityBetween(settings1, settings2,
      settings => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() },
      settings1.SequenceEqual(settings2));

  private readonly OptionAstChecks _checks = new();

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}

internal sealed class OptionAstChecks()
  : AstAliasedChecks<OptionDeclAst>(CreateOption)
{
  private static OptionDeclAst CloneOption(OptionDeclAst original, string input)
    => original with { Name = input };
  private static OptionDeclAst CreateOption(string input)
    => new(AstNulls.At, input);
}
