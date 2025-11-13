
namespace GqlPlus.Ast.Schema.Globals;

public class OptionSettingAstTests
  : AstAliasedTests<SettingInput>
{
  [Theory, RepeatData]
  public void Inequality_ByNames(string name1, string name2, string value)
    => _checks.InequalityBetween(name1, name2,
      name => CreateSetting(name, value),
      name1.NullEqual(name2));

  [Theory, RepeatData]
  public void Inequality_ByValues(string name, string value1, string value2)
    => _checks.InequalityBetween(value1, value2,
      value => CreateSetting(name, value),
      value1.NullEqual(value2));

  protected override string AliasesString(SettingInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} =( !k '{input.Value}' ) )";

  private readonly AstAliasedChecks<SettingInput, OptionSettingAst> _checks
    = new(CreateSetting, CloneSetting);

  private static OptionSettingAst CloneSetting(OptionSettingAst original, SettingInput input)
    => original with { Name = input.Name };
  private static OptionSettingAst CreateSetting(SettingInput input)
    => CreateSetting(input.Name, input.Value);

  internal override IAstAliasedChecks<SettingInput> AliasedChecks => _checks;

  private static OptionSettingAst CreateSetting(string name, string value)
    => new(AstNulls.At, name, new ConstantAst(new FieldKeyAst(AstNulls.At, value)));
  protected override string InputName(SettingInput input) => input.Name;
}

public record struct SettingInput(string Name, string Value);
