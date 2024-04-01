﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class SettingModelTests(
  IModeller<OptionSettingAst, SettingModel> modeller
) : TestDescribedModel<SettingInput>
{
  internal override ICheckDescribedModel<SettingInput> DescribedChecks => _checks;

  private readonly SettingModelChecks _checks = new(modeller);
}

internal sealed class SettingModelChecks(
  IModeller<OptionSettingAst, SettingModel> modeller
) : CheckDescribedModel<SettingInput, OptionSettingAst, SettingModel>(modeller)
{
  protected override string[] ExpectedDescription(ExpectedDescriptionInput<SettingInput> input)
    => input.Name.Expected(input.Description ?? []);

  protected override OptionSettingAst NewDescribedAst(SettingInput input, string description)
    => input.ToAst(description);
}

public record struct SettingInput(string Name, string Value)
{
  internal readonly OptionSettingAst ToAst(string description)
    => new(AstNulls.At, Name, description, new FieldKeyAst(AstNulls.At, Value));

  internal readonly string[] Expected(string[] description, string prefix = "", string indent = "")
    => [prefix + "!_Setting",
      .. description.Select(d => indent + d),
      indent + "name: " + Name,
      indent + "value: " + Value.YamlQuoted()];
}
