using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class ParameterModelTests // : ModelDescribedTests<string>
{
  //[Theory, RepeatData(Repeats)]
  //public void Model_All(string name, string contents, string[] parameters, string[] aliases, ParameterOption option, ParameterLocation[] locations)
  //  => _checks.AstExpected(
  //    new(AstNulls.At, name) {
  //      Aliases = aliases,
  //      Description = contents,
  //      Locations = locations.Combine(),
  //      Option = option,
  //      Parameters = parameters.Parameters(),
  //    },
  //    ["!_Parameter",
  //      $"aliases: [{string.Join(", ", aliases)}]",
  //      "description: " + ModelBaseChecks.YamlQuoted(contents),
  //      "locations: !_Set(_Location) " + ExpectedLocations(locations),
  //      "name: " + name,
  //      "parameters:",
  //      .. parameters.Select(p => "- !_Parameter ''"),
  //      "repeatable: " + (option == ParameterOption.Repeatable).TrueFalse()]);

  //protected override string[] ExpectedDescription(string input, string description)
  //  => ["!_Parameter",
  //    description,
  //  ];

  //internal override IModelDescribedChecks<string> DescribedChecks => _checks;

  private readonly ParameterModelChecks _checks = new();
}

internal sealed class ParameterModelChecks
  : ModelDescribedChecks<string, ParameterAst>
{
  internal readonly IModeller<ParameterAst> Parameter;
  internal readonly IModeller<ModifierAst> Modifier;

  public ParameterModelChecks()
    => Parameter = new ParameterModeller(
      Modifier = ForModeller<ModifierAst, ModifierModel>(
        m => new(m.Kind)));

  protected override IRendering AstToModel(ParameterAst ast)
    => Parameter.ToRenderer(ast);

  protected override ParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
