using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Globals;

public class DirectiveModelTests(
  IDirectiveModelChecks checks
) : TestAliasedModel<string, DirectiveModel>(checks)
{
  [Theory, RepeatData]
  public void Model_Repeatable(string name, DirectiveOption option)
    => checks.DirectiveExpected(
      new DirectiveDeclAst(AstNulls.At, name) { Option = option },
      new(name, option: option));

  [Theory, RepeatData]
  public void Model_Params(string name, string[] parameters)
    => checks.DirectiveExpected(
      new DirectiveDeclAst(AstNulls.At, name) { Params = parameters.Params() },
      new(name, parameters: checks.ExpectedParams(parameters)));

  [Theory, RepeatData]
  public void Model_Locations(string name, DirectiveLocation locations)
    => checks.DirectiveExpected(
      new DirectiveDeclAst(AstNulls.At, name) { Locations = locations },
      new(name, locations: ExpectedLocations(locations)));

  [Theory, RepeatData]
  public void Model_All(
    string name,
    string contents,
    string[] parameters,
    string[] aliases,
    DirectiveOption option,
    DirectiveLocation location
  ) => checks.DirectiveExpected(
      new DirectiveDeclAst(AstNulls.At, name) {
        Aliases = aliases,
        Description = contents,
        Locations = location,
        Option = option,
        Params = parameters.Params(),
      },
      new(name, aliases, contents, checks.ExpectedParams(parameters), option, ExpectedLocations(location)));

  private static string[] ExpectedLocations(DirectiveLocation location)
  {
    IOrderedEnumerable<string> labels = Enum.GetValues<DirectiveLocation>()
      .Where(v => int.PopCount((int)v) == 1)
      .Where(l => location.HasFlag(l))
      .Select(l => $"{l}:_").Order();

    return [labels.Surround("locations: !_Set(_Location){", "}", ",")];
  }
}

internal sealed class DirectiveModelChecks(
  IModeller<IGqlpSchemaDirective, DirectiveModel> modeller,
  IEncoder<DirectiveModel> encoding
) : CheckAliasedModel<string, IGqlpSchemaDirective, DirectiveDeclAst, DirectiveModel>(modeller, encoding)
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
      .. input.Params,
      input.Repeatable];

  public string[] ExpectedParams(string[] parameters)
    => [.. ItemsExpected(
       "parameters:",
        parameters,
        p => ["  - !_InputParam", "    input: " + p])];

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
  public string[] Params { get; } = parameters ?? [];
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
  string[] ExpectedParams(string[] parameters);
}
