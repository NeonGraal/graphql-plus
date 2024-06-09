namespace GqlPlus.Models;

public record class AndTypeModel<TModel>
  : ModelBase
  where TModel : ModelBase
{
  private readonly string _field;

  public AndTypeModel(string field)
    => _field = field;

  public TModel? And { get; set; }

  public BaseTypeModel? Type { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => Type is null
      ? And is null
        ? new("")
        : And.Render(context)
      : And is null
        ? Type.Render(context)
        : base.Render(context)
          .Add(_field, And.Render(context))
          .Add("type", Type.Render(context));
}

public record class CategoriesModel()
  : AndTypeModel<CategoryModel>("category")
{ }

public record class CategoryModel(
  string Name, TypeRefModel<TypeKindModel> Output
) : AliasedModel(Name)
{
  public CategoryOption Resolution { get; set; } = CategoryOption.Parallel;
  public ModifierModel[] Modifiers { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("resolution", Resolution, "_Resolution")
      .Add("output", Output.Render(context))
      .Add("modifiers", Modifiers.Render(context, flow: true));
}

public record class DirectivesModel()
  : AndTypeModel<DirectiveModel>("directive")
{ }

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

public record class SettingModel(
  string Name,
  ConstantModel Value
) : DescribedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("value", Value.Render(context));
}
