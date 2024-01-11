namespace GqlPlus.Verifier.Model;

public class SettingModelTests : ModelDescribedTests<SettingInput>
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
      "name: " + input.Name];

  internal override IModelDescribedChecks<SettingInput> DescribedChecks => _checks;

  private readonly SettingModelChecks _checks = new();
}
