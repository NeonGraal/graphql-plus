using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Schema.Globals;

public class OptionAstTests
  : AstAliasedTests
{
  [Theory, RepeatData]
  public void HashCode_WithSettings(string name, string[] settings)
      => _checks.HashCode(
        () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() });

  [Theory, RepeatData]
  public void String_WithSettings(string name, string[] settings)
    => _checks.Text(
      () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() },
      $"( !Op {name} {{ {settings.Joined(s => $"!OS {s} =( !k '{s}' )")} }} )");

  [Theory, RepeatData]
  public void Equality_WithSettings(string name, string[] settings)
    => _checks.Equality(
      () => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() });

  [SkippableTheory, RepeatData]
  public void Inequality_BetweenSettings(string name, string[] settings1, string[] settings2)
    => _checks.InequalityBetween(settings1, settings2,
      settings => new OptionDeclAst(AstNulls.At, name) { Settings = settings.OptionSettings() },
      settings1.SequenceEqual(settings2));

  protected override string AliasesString(string input, string aliases)
    => $"( !Op {input}{aliases} )";

  private readonly AstAliasedChecks<OptionDeclAst> _checks
    = new(name => new OptionDeclAst(AstNulls.At, name));

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override Func<string, string, bool> SameInput
    => (name1, name2) => name1.Camelize() == name2.Camelize();
}
