namespace GqlPlus.Rendering;

internal class SchemaRenderer(
  IRenderer<CategoriesModel> categories,
  IRenderer<DirectivesModel> directives,
  IRenderer<BaseTypeModel> types,
  IRenderer<SettingModel> settings
) : AliasedRenderer<SchemaModel>
{
  internal override Structured Render(SchemaModel model)
    => base.Render(model)
      .AddMap("categories", model.GetCategories(default), categories, "_Categories")
      .AddMap("directives", model.GetDirectives(default), directives, "_Directives")
      .AddMap("types", model.GetTypes(default), types, "_Type")
      .AddMap("settings", model.GetSettings(default), settings, "_Setting")
      .Add("_errors", model.Errors.Render());
}
