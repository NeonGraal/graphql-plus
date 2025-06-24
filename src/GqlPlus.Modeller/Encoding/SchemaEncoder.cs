namespace GqlPlus.Encoding;

internal class SchemaEncoder(
  IEncoder<CategoriesModel> categories,
  IEncoder<DirectivesModel> directives,
  IEncoder<BaseTypeModel> types,
  IEncoder<SettingModel> settings
) : AliasedEncoder<SchemaModel>
{
  internal override Structured Encode(SchemaModel model)
    => base.Encode(model)
      .AddMap("categories", model.GetCategories(default), categories, "_Categories")
      .AddMap("directives", model.GetDirectives(default), directives, "_Directives")
      .AddMap("types", model.GetTypes(default), types, "_Type")
      .AddMap("settings", model.GetSettings(default), settings, "_Setting")
      .Add("_errors", model.Errors.Encode());
}
