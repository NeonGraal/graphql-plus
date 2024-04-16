using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling.Globals;

public class DirectiveModelTests(
  IModeller<DirectiveDeclAst, DirectiveModel> modeller
) : TestAliasedModel<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Repeatable(string name, DirectiveOption option)
    => _checks.DirectiveExpected(
      new(AstNulls.At, name) { Option = option },
      new(name, option: option));

  [Theory, RepeatData(Repeats)]
  public void Model_Parameters(string name, string[] parameters)
    => _checks.DirectiveExpected(
      new(AstNulls.At, name) { Parameters = parameters.Parameters() },
      new(name, parameters: _checks.ExpectedParameters(parameters)));

  [Theory, RepeatData(Repeats)]
  public void Model_Locations(string name, DirectiveLocation[] locations)
    => _checks.DirectiveExpected(
      new(AstNulls.At, name) { Locations = DirectiveModeller.Combine(locations) },
      new(name, locations: "locations: !_Set(_Location) " + ExpectedLocations(locations)));

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    string name,
    string contents,
    string[] parameters,
    string[] aliases,
    DirectiveOption option,
    DirectiveLocation[] locations
  ) => _checks.DirectiveExpected(
      new(AstNulls.At, name) {
        Aliases = aliases,
        Description = contents,
        Locations = DirectiveModeller.Combine(locations),
        Option = option,
        Parameters = parameters.Parameters(),
      },
      new(name, aliases, contents, _checks.ExpectedParameters(parameters), option, "locations: !_Set(_Location) " + ExpectedLocations(locations)));

  private static string ExpectedLocations(DirectiveLocation[] locations)
  {
    var location = DirectiveModeller.Combine(locations);
    var labels = Enum.GetValues<DirectiveLocation>()
      .Where(v => int.PopCount((int)v) == 1)
      .Where(l => location.HasFlag(l))
      .Select(l => $"{l}: _").Order();
    return "{" + string.Join(", ", labels) + "}";
  }

  internal override ICheckAliasedModel<string> AliasedChecks => _checks;

  private readonly DirectiveModelChecks _checks = new(modeller);
}

internal sealed class DirectiveModelChecks(
  IModeller<DirectiveDeclAst, DirectiveModel> modeller
) : CheckAliasedModel<string, DirectiveDeclAst, DirectiveModel>(modeller)
{
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ExpectedDirective(new(input));

  protected override DirectiveDeclAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);

  internal string[] ExpectedDirective(ExpectedDirectiveInput input)
    => ["!_Directive",
        .. input.Aliases,
        .. input.Description,
        .. input.Locations,
        "name: " + input.Name,
        .. input.Parameters,
        input.Repeatable];

  internal string[] ExpectedParameters(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["- !_Parameter", "  type: !_InputBase " + p])];

  internal void DirectiveExpected(DirectiveDeclAst ast, ExpectedDirectiveInput input)
    => AstExpected(ast, ExpectedDirective(input));
}

internal sealed class ExpectedDirectiveInput(
  string name,
  IEnumerable<string>? aliases = null,
  string? description = null,
  string[]? parameters = null,
  DirectiveOption option = DirectiveOption.Unique,
  string? locations = null
) : ExpectedDescriptionAliasesInput<string>(name, aliases, description)
{
  public string[] Parameters { get; } = parameters ?? [];
  public string Repeatable { get; } = "repeatable: " + (option == DirectiveOption.Repeatable).TrueFalse();
  public string[] Locations { get; } = [locations ?? ""];

  internal ExpectedDirectiveInput(ExpectedDescriptionAliasesInput<string> input)
    : this(input.Name)
  {
    Aliases = input.Aliases;
    Description = input.Description;
  }
}
