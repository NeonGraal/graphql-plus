namespace GqlPlus.Verifier.Modelling;

public class ConstantModelTests(
  IModeller<ConstantAst, ConstantModel> modeller
) : ModelBaseTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_List(string value)
    => _checks
    .AstExpected(
      new(AstNulls.At, value.ConstantList()),
      ["- " + value, "- " + value]);

  [Theory, RepeatData(Repeats)]
  public void Model_Object(string key, string value)
  {
    if (key == value) {
      return;
    }

    _checks
      .AstExpected(
        new(AstNulls.At, value.ConstantObject(key)),
        ["!_ConstantMap", key + ": " + value, value + ": " + key]);
  }

  //[Theory, RepeatData(Repeats)]
  //public void Model_All(string name, string contents, string[] parameters, string[] aliases, ConstantOption option, ConstantLocation[] locations)
  //  => _checks.AstExpected(
  //    new(AstNulls.At, name) {
  //      Aliases = aliases,
  //      Description = contents,
  //      Locations = locations.Combine(),
  //      Option = option,
  //      Constants = parameters.Constants(),
  //    },
  //    ["!_Constant",
  //      $"aliases: [{string.Join(", ", aliases)}]",
  //      "description: " + ModelBaseChecks.YamlQuoted(contents),
  //      "locations: !_Set(_Location) " + ExpectedLocations(locations),
  //      "name: " + name,
  //      "parameters:",
  //      .. parameters.Select(p => "- !_Constant ''"),
  //      "repeatable: " + (option == ConstantOption.Repeatable).TrueFalse()]);

  internal override IModelBaseChecks<string> BaseChecks => _checks;
  protected override string[] ExpectedBase(string input)
    => [input];

  private readonly ConstantModelChecks _checks = new(modeller);
}

internal sealed class ConstantModelChecks(
  IModeller<ConstantAst, ConstantModel> modeller
) : ModelBaseChecks<string, ConstantAst, ConstantModel>(modeller)
{
  protected override ConstantAst NewBaseAst(string input)
    => new FieldKeyAst(AstNulls.At, input);
}
