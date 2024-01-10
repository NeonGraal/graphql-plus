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
}
