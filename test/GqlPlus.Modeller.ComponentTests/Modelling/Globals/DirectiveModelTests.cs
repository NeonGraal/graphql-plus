using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Modelling.Globals;

public class DirectiveModelTests(
  IModeller<IGqlpSchemaDirective, DirectiveModel> modeller
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
      new(name, locations: ExpectedLocations(locations)));

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
      new(name, aliases, contents, _checks.ExpectedParameters(parameters), option, ExpectedLocations(locations)));

  private static string[] ExpectedLocations(DirectiveLocation[] locations)
  {
    DirectiveLocation location = DirectiveModeller.Combine(locations);
    IOrderedEnumerable<string> labels = Enum.GetValues<DirectiveLocation>()
      .Where(v => int.PopCount((int)v) == 1)
      .Where(l => location.HasFlag(l))
      .Select(l => $"{l}: _").Order();

    return labels.YamlWidth("locations: !_Set(_Location) {", "}");
  }

  internal override ICheckAliasedModel<string> AliasedChecks => _checks;

  private readonly DirectiveModelChecks _checks = new(modeller);
}

internal sealed class DirectiveModelChecks(
  IModeller<IGqlpSchemaDirective, DirectiveModel> modeller
) : CheckAliasedModel<string, IGqlpSchemaDirective, DirectiveDeclAst, DirectiveModel>(modeller)
{
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ExpectedDirective(new(input));

  protected override DirectiveDeclAst NewAliasedAst(string name, string? description = null, string[]? aliases = null)
    => new(AstNulls.At, name, description ?? "") { Aliases = aliases ?? [], };

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
        p => ["- !_InputParameter", "  type: !_InputBase", "    input: " + p])];

  internal void DirectiveExpected(DirectiveDeclAst ast, ExpectedDirectiveInput input)
    => AstExpected(ast, ExpectedDirective(input));
}

internal sealed class ExpectedDirectiveInput(
  string name,
  IEnumerable<string>? aliases = null,
  string? description = null,
  string[]? parameters = null,
  DirectiveOption option = DirectiveOption.Unique,
  string[]? locations = null
) : ExpectedDescriptionAliasesInput<string>(name, aliases, description)
{
  public string[] Parameters { get; } = parameters ?? [];
  public string Repeatable { get; } = "repeatable: " + (option == DirectiveOption.Repeatable).TrueFalse();
  public string[] Locations { get; } = locations ?? [];

  internal ExpectedDirectiveInput(ExpectedDescriptionAliasesInput<string> input)
    : this(input.Name)
  {
    Aliases = input.Aliases;
    Description = input.Description;
  }
}
