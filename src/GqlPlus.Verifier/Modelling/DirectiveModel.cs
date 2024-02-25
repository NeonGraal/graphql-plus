using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal record class DirectiveModel(string Name)
  : AliasedModel(Name)
{
  public ParameterModel[] Parameters { get; set; } = [];
  public bool Repeatable { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override RenderStructure Render()
    => base.Render()
      .Add("locations", new("_Set(_Location)", DirectiveModeller.ToSet(Locations), true))
      .Add("parameters", new("", Parameters.Render()))
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

  internal static RenderStructure.Dict ToSet(DirectiveLocation locations)
  {
    var result = new RenderStructure.Dict();

    foreach (var location in Enum.GetValues<DirectiveLocation>()) {
      if (ActualFlag(location) && locations.HasFlag(location)) {
        result.Add(new($"{location}"), new("", "_"));
      }
    }

    return result;
  }

  internal static bool ActualFlag(DirectiveLocation location)
    => location is not DirectiveLocation.None and not DirectiveLocation.None;

  internal static DirectiveLocation Combine(DirectiveLocation[] values)
    => values.Aggregate((a, b) => a | b);
}
