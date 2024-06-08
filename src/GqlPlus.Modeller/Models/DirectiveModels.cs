namespace GqlPlus.Models;

public record class DirectivesModel
  : ModelBase
{
  public DirectiveModel? Directive { get; init; }
  public BaseTypeModel? Type { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => Type is null
      ? Directive is null
        ? new("")
        : Directive.Render(context)
      : Directive is null
        ? Type.Render(context)
        : base.Render(context)
          .Add("directive", Directive.Render(context))
          .Add("type", Type.Render(context));
}

public record class DirectiveModel(
  string Name
) : AliasedModel(Name)
{
  public InputParameterModel[] Parameters { get; set; } = [];
  public bool Repeatable { get; set; }
  public DirectiveLocation Locations { get; set; } = DirectiveLocation.None;

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .AddSet("locations", Locations, "_Location")
      .Add("parameters", Parameters.Render(context))
      .Add("repeatable", Repeatable);
}
