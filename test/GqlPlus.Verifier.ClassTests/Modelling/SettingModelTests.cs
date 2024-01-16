using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class SettingModelTests
  : ModelDescribedTests<SettingInput>
{
  //[Theory, RepeatData(Repeats)]
  //public void Model_All(string name, string contents, string[] parameters, string[] aliases, SettingOption option, SettingLocation[] locations)
  //  => _checks.AstExpected(
  //    new(AstNulls.At, name) {
  //      Aliases = aliases,
  //      Description = contents,
  //      Locations = locations.Combine(),
  //      Option = option,
  //      Parameters = parameters.Parameters(),
  //    },
  //    ["!_Setting",
  //      $"aliases: [{string.Join(", ", aliases)}]",
  //      "description: " + ModelBaseChecks.YamlQuoted(contents),
  //      "locations: !_Set(_Location) " + ExpectedLocations(locations),
  //      "name: " + name,
  //      "parameters:",
  //      .. parameters.Select(p => "- !_Parameter ''"),
  //      "repeatable: " + (option == SettingOption.Repeatable).TrueFalse()]);

  protected override string[] ExpectedDescription(SettingInput input, string description)
    => ["!_Setting",
      description,
      "name: " + input.Name,
      "value: " + input.Value];

  internal override IModelDescribedChecks<SettingInput> DescribedChecks => _checks;

  private readonly SettingModelChecks _checks = new();
}

internal sealed class SettingModelChecks
  : ModelDescribedChecks<SettingInput, OptionSettingAst>
{
  internal readonly IModeller<OptionSettingAst> Setting;
  internal readonly IModeller<ConstantAst> Constant;

  public SettingModelChecks()
    => Setting = new SettingModeller(
      Constant = ForModeller<ConstantAst, ConstantModel>(
        a => new(new SimpleModel(a.Value?.Value ?? a.Value?.String ?? ""))));

  protected override IRendering AstToModel(OptionSettingAst ast)
    => Setting.ToRenderer(ast);

  protected override OptionSettingAst NewDescribedAst(SettingInput input, string description)
    => input.ToAst(description);
}

public record struct SettingInput(string Name, string Value)
{
  internal readonly OptionSettingAst ToAst(string description)
    => new(AstNulls.At, Name, description, new FieldKeyAst(AstNulls.At, Value));
}
