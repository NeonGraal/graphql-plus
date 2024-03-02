using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

// Todo : DirectivesModel

internal record class DirectiveModel(string Name)
  : AliasedModel(Name)
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

internal class DirectiveModeller
  : ModellerBase<DirectiveDeclAst, DirectiveModel>
{
  internal override DirectiveModel ToModel(DirectiveDeclAst ast)
    => new(ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Repeatable = ast.Option == DirectiveOption.Repeatable,
      Locations = ast.Locations,
      // Todo: Parameters = [.. category.Parameters.Select(p => p.ToModel())],
    };

  internal static DirectiveLocation Combine(DirectiveLocation[] values)
    => values.Aggregate((a, b) => a | b);
}
