namespace GqlPlus.Verifier.Ast.Schema;

public class OptionAstTests : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithSettings(string name, string[] settings)
      => _checks.HashCode(
        () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() });

  [Theory, RepeatData(Repeats)]
  public void String_WithSettings(string name, string[] settings)
    => _checks.String(
      () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() },
      $"( !O {name} {{ {settings.Joined(s => $"!OS {s} =( !k '{s}' )")} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithSettings(string name, string[] settings)
    => _checks.Equality(
      () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenSettings(string name, string[] settings1, string[] settings2)
    => _checks.InequalityBetween(settings1, settings2,
      settings => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() },
      settings1.SequenceEqual(settings2));

  protected override string AliasesString(string input, string aliases)
    => $"( !O {input}{aliases} )";

  private readonly AstAliasedChecks<OptionDeclAst> _checks
    = new(name => new OptionDeclAst(AstNulls.At, name)) {
      SameInput = (name1, name2) => name1.Camelize() == name2.Camelize()
    };

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;
}
