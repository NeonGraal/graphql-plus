namespace GqlPlus.Verifier.Ast.Schema;

public class OptionAstTests : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithSettings(string name, string setting, string value)
      => _checks.HashCode(
        () => new OptionDeclAst(AstNulls.At, name) { Settings = setting.OptionSettings(value) });

  [Theory, RepeatData(Repeats)]
  public void String_WithSettings(string name, string setting, string value)
    => _checks.String(
      () => new OptionDeclAst(AstNulls.At, name) { Settings = setting.OptionSettings(value) },
      $"( !O {name} {{ {setting}=( !k '{value}' ) }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithSettings(string name, string setting, string value)
    => _checks.Equality(
      () => new OptionDeclAst(AstNulls.At, name) { Settings = setting.OptionSettings(value) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenSettings(string name, string setting1, string setting2, string value)
    => _checks.InequalityBetween(setting1, setting2,
      setting => new OptionDeclAst(AstNulls.At, name) { Settings = setting.OptionSettings(value) },
      setting1 == setting2);

  protected override string InputString(string input)
    => $"( !O {input} )";

  protected override string AliasesString(string input, params string[] aliases)
    => $"( !O {input} [ {aliases.Joined()} ] )";

  private readonly AstAliasedChecks<OptionDeclAst> _checks
    = new(name => new OptionDeclAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;
}
