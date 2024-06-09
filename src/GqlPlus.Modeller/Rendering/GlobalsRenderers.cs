namespace GqlPlus.Rendering;

internal class AndTypeRenderer<TModel, TAnd>(
  string field,
  IRenderer<TAnd> and
) : BaseRenderer<TModel>
  where TModel : AndTypeModel<TAnd>
  where TAnd : ModelBase
{
  private readonly string _field = field;

  internal override RenderStructure Render(TModel model, IRenderContext context)
    => model.Type is null
      ? model.And is null
        ? new("")
        : and.Render(model.And, context)
      : model.And is null
        ? model.Type.Render(context)
        : base.Render(model, context)
          .Add(_field, and.Render(model.And, context))
          .Add("type", model.Type.Render(context));
}

internal class CategoriesRenderer(
  IRenderer<CategoryModel> and
) : AndTypeRenderer<CategoriesModel, CategoryModel>("category", and)
{ }

internal class CategoryRenderer
  : AliasedRenderer<CategoryModel>
{
  internal override RenderStructure Render(CategoryModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("resolution", model.Resolution, "_Resolution")
      .Add("output", model.Output.Render(context))
      .Add("modifiers", model.Modifiers.Render(context, flow: true));
}

internal class DirectivesRenderer(
  IRenderer<DirectiveModel> and
) : AndTypeRenderer<DirectivesModel, DirectiveModel>("directive", and)
{ }

internal class DirectiveRenderer
  : AliasedRenderer<DirectiveModel>
{
  internal override RenderStructure Render(DirectiveModel model, IRenderContext context)
    => base.Render(model, context)
      .AddSet("locations", model.Locations, "_Location")
      .Add("parameters", model.Parameters.Render(context))
      .Add("repeatable", model.Repeatable);
}

internal class SettingRenderer
  : DescribedRenderer<SettingModel>
{
  internal override RenderStructure Render(SettingModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("value", model.Value.Render(context));
}
