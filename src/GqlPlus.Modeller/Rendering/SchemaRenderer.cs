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
      .Add("categories", model.GetCategories(default), categories, "_Categories")
      .Add("directives", model.GetDirectives(default), directives, "_Directives")
      .Add("types", model.GetTypes(default), types, "_Type")
      .Add("settings", model.GetSettings(default), settings, "_Setting")
      .Add("_errors", model.Errors.Render());
}
