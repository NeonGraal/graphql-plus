using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Schema.Globals;

public class OptionSettingAstTests
  : AstAliasedTests<SettingInput>
{
  [Theory, RepeatData]
  public void Inequality_ByNames(string name1, string name2, string value)
    => _checks.InequalityBetween(name1, name2,
      name => Setting(name, value),
      name1.NullEqual(name2));

  [Theory, RepeatData]
  public void Inequality_ByValues(string name, string value1, string value2)
    => _checks.InequalityBetween(value1, value2,
      value => Setting(name, value),
      value1.NullEqual(value2));

  protected override string AliasesString(SettingInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} =( !k '{input.Value}' ) )";

  private readonly AstAliasedChecks<SettingInput, OptionSettingAst> _checks
    = new(input => Setting(input.Name, input.Value));

  internal override IAstAliasedChecks<SettingInput> AliasedChecks => _checks;

  private static OptionSettingAst Setting(string name, string value)
    => new(AstNulls.At, name, new(new FieldKeyAst(AstNulls.At, value)));
  protected override string InputName(SettingInput input) => input.Name;
}

public record struct SettingInput(string Name, string Value);
