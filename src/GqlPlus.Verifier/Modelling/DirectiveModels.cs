using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// Todo : DirectivesModel

public record class DirectiveModel(
  string Name
) : AliasedModel(Name)
{
  public ParameterModel[] Parameters { get; set; } = [];
  public bool Repeatable { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override RenderStructure Render()
    => base.Render()
      .AddSet("locations", Locations, "_Location")
      .Add("parameters", Parameters.Render())
      .Add("repeatable", Repeatable);
}

internal class DirectiveModeller(
  IModeller<ParameterAst, ParameterModel> parameter
) : ModellerBase<DirectiveDeclAst, DirectiveModel>
{
  internal override DirectiveModel ToModel(DirectiveDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Repeatable = ast.Option == DirectiveOption.Repeatable,
      Locations = ast.Locations,
      Parameters = parameter.ToModels(ast.Parameters),
    };

  internal static DirectiveLocation Combine(DirectiveLocation[] values)
    => values.Aggregate((a, b) => a | b);
}
