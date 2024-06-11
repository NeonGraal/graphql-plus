namespace GqlPlus.Rendering;

internal class SchemaRenderer(
  IRenderer<CategoriesModel> categories,
  IRenderer<DirectivesModel> directives,
  IRenderer<BaseTypeModel> types,
  IRenderer<SettingModel> settings
) : AliasedRenderer<SchemaModel>
{
  internal override RenderStructure Render(SchemaModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("categories", model.GetCategories(default).Render(categories, context, "_Categories"))
      .Add("directives", model.GetDirectives(default).Render(directives, context, "_Directives"))
      .Add("types", model.GetTypes(default).Render(types, context, "_Type"))
      .Add("settings", model.GetSettings(default).Render(settings, context, "_Setting"))
      .Add("_errors", model.Errors.Render());
}
