using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Model;

internal record class DirectiveModel(string Name)
  : ModelAliased(Name)
{
  public ParameterModel[] Parameters { get; set; } = [];
  public bool Repeatable { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  protected override string Tag => "Directive";

  public override RenderValue Render()
    => base.Render()
      .Add("locations", new("_Set(_Location)", Locations.ToSet(), true))
      .Add("parameters", new("", Parameters.Select(p => p.Render())))
      .Add("repeatable", new("", Repeatable));
}

internal static class DirectiveHelper
{
  internal static DirectiveModel ToModel(this DirectiveDeclAst category)
  => new(category.Name) {
    Aliases = category.Aliases,
    Description = category.Description,
    Repeatable = category.Option == DirectiveOption.Repeatable,
    Locations = category.Locations,
    Parameters = [.. category.Parameters.Select(p => p.ToModel())],
  };

  internal static IReadOnlyMap<RenderValue> ToSet(this DirectiveLocation locations)
  {
    var result = new Map<RenderValue>();

    foreach (var location in Enum.GetValues<DirectiveLocation>()) {
      if (location.ActualFlag() && locations.HasFlag(location)) {
        result.Add($"{location}", new("", "_"));
      }
    }

    return result;
  }

  internal static bool ActualFlag(this DirectiveLocation location)
    => location is not DirectiveLocation.None and not DirectiveLocation.None;

  internal static DirectiveLocation Combine(this DirectiveLocation[] values)
    => values.Aggregate((a, b) => a | b);
}
