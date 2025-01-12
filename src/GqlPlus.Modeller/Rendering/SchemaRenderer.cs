namespace GqlPlus.Rendering;

internal class SchemaRenderer(
  IRenderer<CategoriesModel> categories,
  IRenderer<DirectivesModel> directives,
  IRenderer<OperationsModel> operations,
  IRenderer<SettingModel> settings,
  IRenderer<BaseTypeModel> types
) : AliasedRenderer<SchemaModel>
{
  internal override RenderStructure Render(SchemaModel model)
    => base.Render(model)
      .Add("categories", model.GetCategories(default), categories, "_Categories")
      .Add("directives", model.GetDirectives(default), directives, "_Directives")
      .Add("operations", model.GetOperations(default), operations, "_Operations")
      .Add("settings", model.GetSettings(default), settings, "_Setting")
      .Add("types", model.GetTypes(default), types, "_Type")
      .Add("_errors", model.Errors.Render());
}
