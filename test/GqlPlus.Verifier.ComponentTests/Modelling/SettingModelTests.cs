using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class SettingModelTests(
  IModeller<OptionSettingAst, SettingModel> modeller
) : TestDescribedModel<SettingInput>
{
  protected override string[] ExpectedDescription(SettingInput input, string description)
    => ["!_Setting",
      description,
      "name: " + input.Name,
      "value: " + input.Value];

  internal override ICheckDescribedModel<SettingInput> DescribedChecks => _checks;

  private readonly SettingModelChecks _checks = new(modeller);
}

internal sealed class SettingModelChecks(
  IModeller<OptionSettingAst, SettingModel> modeller
) : CheckDescribedModel<SettingInput, OptionSettingAst, SettingModel>(modeller)
{
  protected override OptionSettingAst NewDescribedAst(SettingInput input, string description)
    => input.ToAst(description);
}

public record struct SettingInput(string Name, string Value)
{
  internal readonly OptionSettingAst ToAst(string description)
    => new(AstNulls.At, Name, description, new FieldKeyAst(AstNulls.At, Value));
}
