﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

public class DirectiveModelTests : ModelAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Repeatable(string name, DirectiveOption option)
    => DirectiveModelChecks.Directive_Expected(
      new(AstNulls.At, name) { Option = option },
      ["!_Directive",
        "name: " + name,
        "repeatable: " + (option == DirectiveOption.Repeatable).TrueFalse()]);

  [Theory, RepeatData(Repeats)]
  public void Model_Parameters(string name, string[] parameters)
    => DirectiveModelChecks.Directive_Expected(
      new(AstNulls.At, name) { Parameters = parameters.Parameters() },
      ["!_Directive",
        "name: " + name,
        "parameters:",
        .. parameters.Select(p => "- !_Parameter ''"),
        "repeatable: false"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Locations(string name, DirectiveLocation[] locations)
    => DirectiveModelChecks.Directive_Expected(
      new(AstNulls.At, name) { Locations = locations.Combine() },
      ["!_Directive",
        "locations: !_Set(_Location) " + ExpectedLocations(locations),
        "name: " + name,
        "repeatable: false"]);

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] parameters, string[] aliases, DirectiveOption option, DirectiveLocation[] locations)
    => DirectiveModelChecks.Directive_Expected(
      new(AstNulls.At, name) {
        Aliases = aliases,
        Description = contents,
        Locations = locations.Combine(),
        Option = option,
        Parameters = parameters.Parameters(),
      },
      ["!_Directive",
        $"aliases: [{string.Join(", ", aliases)}]",
        "description: " + ModelBaseChecks.YamlQuoted(contents),
        "locations: !_Set(_Location) " + ExpectedLocations(locations),
        "name: " + name,
        "parameters:",
        .. parameters.Select(p => "- !_Parameter ''"),
        "repeatable: " + (option == DirectiveOption.Repeatable).TrueFalse()]);

  private static string ExpectedLocations(DirectiveLocation[] locations)
  {
    var location = locations.Combine();
    var labels = Enum.GetValues<DirectiveLocation>()
      .Where(l => l.ActualFlag())
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

  internal override IModelAliasedChecks AliasedChecks => _checks;

  private readonly DirectiveModelChecks _checks = new();
}