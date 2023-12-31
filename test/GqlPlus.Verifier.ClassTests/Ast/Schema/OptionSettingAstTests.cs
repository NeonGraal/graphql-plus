namespace GqlPlus.Verifier.Ast.Schema;

public class OptionSettingAstTests : AstAliasedTests<SettingInput>
{
  protected override string InputString(SettingInput input)
    => $"( !OS {input.Name} =( !k '{input.Value}' ) )";

  protected override string AliasesString(SettingInput input, params string[] aliases)
    => $"( !OS {input.Name} [ {aliases.Joined()} ] =( !k '{input.Value}' ) )";

  private readonly AstAliasedChecks<SettingInput, OptionSettingAst> _checks
    = new(input => new OptionSettingAst(AstNulls.At, input.Name, new FieldKeyAst(AstNulls.At, input.Value)));

  internal override IAstAliasedChecks<SettingInput> AliasedChecks => _checks;
}

public record struct SettingInput(string Name, string Value);
