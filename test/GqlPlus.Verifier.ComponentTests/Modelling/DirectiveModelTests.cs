using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class DirectiveModelTests(
  IModeller<DirectiveDeclAst, DirectiveModel> modeller
) : AliasedModelTests<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Repeatable(string name, DirectiveOption option)
    => _checks.AstExpected(
      new(AstNulls.At, name) { Option = option },
      ["!_Directive",
        "name: " + name,
        "repeatable: " + (option == DirectiveOption.Repeatable).TrueFalse()]);

  [Theory, RepeatData(Repeats)]
  public void Model_Parameters(string name, string[] parameters)
    => _checks
    .AstExpected(
      new(AstNulls.At, name) { Parameters = parameters.Parameters() },
      ["!_Directive",
        "name: " + name,
        .. DirectiveModelChecks.ExpectedParameters(parameters),
        "repeatable: false"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Locations(string name, DirectiveLocation[] locations)
    => _checks.AstExpected(
      new(AstNulls.At, name) { Locations = DirectiveModeller.Combine(locations) },
      ["!_Directive",
        "locations: !_Set(_Location) " + ExpectedLocations(locations),
        "name: " + name,
        "repeatable: false"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    string name,
    string contents,
    string[] parameters,
    string[] aliases,
    DirectiveOption option,
    DirectiveLocation[] locations
  ) => _checks
    .AstExpected(
      new(AstNulls.At, name) {
        Aliases = aliases,
        Description = contents,
        Locations = DirectiveModeller.Combine(locations),
        Option = option,
        Parameters = parameters.Parameters(),
      },
      ["!_Directive",
        $"aliases: [{string.Join(", ", aliases)}]",
        "description: " + _checks.YamlQuoted(contents),
        "locations: !_Set(_Location) " + ExpectedLocations(locations),
        "name: " + name,
        .. DirectiveModelChecks.ExpectedParameters(parameters),
        "repeatable: " + (option == DirectiveOption.Repeatable).TrueFalse()]);

  private static string ExpectedLocations(DirectiveLocation[] locations)
  {
    var location = DirectiveModeller.Combine(locations);
    var labels = Enum.GetValues<DirectiveLocation>()
      .Where(v => int.PopCount((int)v) == 1)
      .Where(l => location.HasFlag(l))
      .Select(l => $"{l}: _").Order();
    return "{" + string.Join(", ", labels) + "}";
  }

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ["!_Directive",
      aliases,
      description,
      "name: " + input,
      "repeatable: false"];

  internal override IAliasedModelChecks<string> AliasedChecks => _checks;

  private readonly DirectiveModelChecks _checks = new(modeller);
}

internal sealed class DirectiveModelChecks(
  IModeller<DirectiveDeclAst, DirectiveModel> modeller
) : AliasedModelChecks<string, DirectiveDeclAst, DirectiveModel>(modeller)
{
  protected override DirectiveDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);

  internal static IEnumerable<string> ExpectedParameters(string[] parameters)
    => ItemsExpected("parameters:", parameters, p => ["- !_Parameter", "  type: !_Described(_ObjRef(_InputBase)) " + p]);
}
