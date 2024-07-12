using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Convert;

namespace GqlPlus.Modelling.Globals;

public class DirectiveModelTests(
  IDirectiveModelChecks checks
) : TestAliasedModel<string, DirectiveModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_Repeatable(string name, DirectiveOption option)
    => checks.DirectiveExpected(
      new DirectiveDeclAst(AstNulls.At, name) { Option = option },
      new(name, option: option));

  [Theory, RepeatData(Repeats)]
  public void Model_Parameters(string name, string[] parameters)
    => checks.DirectiveExpected(
      new DirectiveDeclAst(AstNulls.At, name) { Parameters = parameters.Parameters() },
      new(name, parameters: checks.ExpectedParameters(parameters)));

  [Theory, RepeatData(Repeats)]
  public void Model_Locations(string name, DirectiveLocation[] locations)
    => checks.DirectiveExpected(
      new DirectiveDeclAst(AstNulls.At, name) { Locations = DirectiveModeller.Combine(locations) },
      new(name, locations: ExpectedLocations(locations)));

  [Theory, RepeatData(Repeats)]
  public void Model_All(
    string name,
    string contents,
    string[] parameters,
    string[] aliases,
    DirectiveOption option,
    DirectiveLocation[] locations
  ) => checks.DirectiveExpected(
      new DirectiveDeclAst(AstNulls.At, name) {
        Aliases = aliases,
        Description = contents,
        Locations = DirectiveModeller.Combine(locations),
        Option = option,
        Parameters = parameters.Parameters(),
      },
      new(name, aliases, contents, checks.ExpectedParameters(parameters), option, ExpectedLocations(locations)));

  private static string[] ExpectedLocations(DirectiveLocation[] locations)
  {
    DirectiveLocation location = DirectiveModeller.Combine(locations);
    IOrderedEnumerable<string> labels = Enum.GetValues<DirectiveLocation>()
      .Where(v => int.PopCount((int)v) == 1)
      .Where(l => location.HasFlag(l))
      .Select(l => $"{l}: _").Order();

    return [labels.YamlJoin("locations: !_Set(_Location) {", "}")];
  }
}

internal sealed class DirectiveModelChecks(
  IModeller<IGqlpSchemaDirective, DirectiveModel> modeller,
  IRenderer<DirectiveModel> rendering
) : CheckAliasedModel<string, IGqlpSchemaDirective, DirectiveDeclAst, DirectiveModel>(modeller, rendering)
  , IDirectiveModelChecks
{
  protected override string[] ExpectedDescriptionAliases(ExpectedDescriptionAliasesInput<string> input)
    => ExpectedDirective(new(input));

  protected override DirectiveDeclAst NewAliasedAst(string name, string? description = null, string[]? aliases = null)
    => new(AstNulls.At, name, description ?? "") { Aliases = aliases ?? [], };

  internal string[] ExpectedDirective(ExpectedDirectiveInput input)
    => ["!_Directive",
      .. input.ExpectedAliases,
      .. input.ExpectedDescription,
      .. input.Locations,
      "name: " + input.Name,
      .. input.Parameters,
      input.Repeatable];

  public string[] ExpectedParameters(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["- !_InputParameter", "  input: " + p])];

  public void DirectiveExpected(IGqlpSchemaDirective ast, ExpectedDirectiveInput input)
    => AstExpected((DirectiveDeclAst)ast, ExpectedDirective(input));
}

public sealed class ExpectedDirectiveInput(
  string name,
  IEnumerable<string>? aliases = null,
  string? description = null,
  string[]? parameters = null,
  DirectiveOption option = DirectiveOption.Unique,
  string[]? locations = null
) : ExpectedDescriptionAliasesInput<string>(name, aliases, description)
{
#pragma warning disable CA1819 // Properties should not return arrays
  public string[] Parameters { get; } = parameters ?? [];
  public string[] Locations { get; } = locations ?? [];
#pragma warning restore CA1819 // Properties should not return arrays
  public string Repeatable { get; } = "repeatable: " + (option == DirectiveOption.Repeatable).TrueFalse();

  internal ExpectedDirectiveInput(ExpectedDescriptionAliasesInput<string> input)
    : this(input.Name)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }
}

public interface IDirectiveModelChecks
  : ICheckAliasedModel<string, DirectiveModel>
{
  void DirectiveExpected(IGqlpSchemaDirective ast, ExpectedDirectiveInput input);
  string[] ExpectedParameters(string[] parameters);
}
