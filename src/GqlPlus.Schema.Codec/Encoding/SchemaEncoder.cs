namespace GqlPlus.Encoding;

internal class SchemaEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<SchemaModel>
{
  private readonly Encoder<CategoriesModel> _categories = encoders.EncoderFor<CategoriesModel>();
  private readonly Encoder<DirectivesModel> _directives = encoders.EncoderFor<DirectivesModel>();
  private readonly Encoder<BaseTypeModel> _types = encoders.EncoderFor<BaseTypeModel>();
  private readonly Encoder<SettingModel> _settings = encoders.EncoderFor<SettingModel>();

  internal override Structured Encode(SchemaModel model)
    => base.Encode(model)
      .AddMap("categories", model.GetCategories(default), _categories, "_Categories")
      .AddMap("directives", model.GetDirectives(default), _directives, "_Directives")
      .AddMap("types", model.GetTypes(default), _types, "_Type")
      .AddMap("settings", model.GetSettings(default), _settings, "_Setting")
      .Add("_errors", model.Errors.Encode());

  internal static new SchemaEncoder Factory(IEncoderRepository r) => new(r);
}
