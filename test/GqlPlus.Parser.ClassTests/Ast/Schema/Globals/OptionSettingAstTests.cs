namespace GqlPlus.Ast.Schema.Globals;

public partial class OptionSettingAstTests
{
  private readonly OptionSettingAstChecks _checks = new();

  [CheckTests(Inherited = true)]
  internal IAstAliasedChecks<SettingInput> AliasedChecks => _checks;

  [CheckTests]
  internal ICloneChecks<SettingInput> CloneChecks { get; }
    = new CloneChecks<SettingInput, OptionSettingAst>(
      OptionSettingAstChecks.CreateSetting,
      (original, input) => original with { Name = input.Name });
}

internal sealed class OptionSettingAstChecks()
  : AstAliasedChecks<SettingInput, OptionSettingAst>(CreateSetting)
{
  public void Inequality_ByNames(string name1, string name2, string value)
    => InequalityBetween(name1, name2,
      name => CreateSetting(name, value),
      name1.NullEqual(name2));

  public void Inequality_ByValues(string name, string value1, string value2)
    => InequalityBetween(value1, value2,
      value => CreateSetting(name, value),
      value1.NullEqual(value2));

  protected override string AliasesString(SettingInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} =( !k '{input.Value}' ) )";

  protected override string InputName(SettingInput input) => input.Name;

  internal static OptionSettingAst CreateSetting(SettingInput input)
    => new(AstNulls.At, input.Name, new ConstantAst(new FieldKeyAst(AstNulls.At, input.Value)));

  internal OptionSettingAst CreateSetting(string name, string value)
    => CreateSetting(new(name, value));
}

public record struct SettingInput(string Name, string Value);
