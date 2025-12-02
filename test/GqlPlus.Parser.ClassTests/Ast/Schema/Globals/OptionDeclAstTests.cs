namespace GqlPlus.Ast.Schema.Globals;

public partial class OptionDeclAstTests
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

  private readonly AstDeclarationChecks<OptionDeclAst> _checks = new(CreateOption);

  [CheckTests(Inherited = true)]
  internal IAstDeclarationChecks AliasedChecks => _checks;

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, OptionDeclAst>(
      CreateOption,
      (original, input) => original with { Name = input });

  private static OptionDeclAst CreateOption(string input)
    => new(AstNulls.At, input);
}
