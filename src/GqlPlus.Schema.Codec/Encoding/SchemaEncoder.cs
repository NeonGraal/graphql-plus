namespace GqlPlus.Encoding;

internal class SchemaEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<SchemaModel>
{
  private readonly DeferOne<IEncoder<CategoriesModel>> _categories = encoders.EncoderFor<CategoriesModel>();
  private readonly DeferOne<IEncoder<DirectivesModel>> _directives = encoders.EncoderFor<DirectivesModel>();
  private readonly DeferOne<IEncoder<BaseTypeModel>> _types = encoders.EncoderFor<BaseTypeModel>();
  private readonly DeferOne<IEncoder<SettingModel>> _settings = encoders.EncoderFor<SettingModel>();

  internal override Structured Encode(SchemaModel model)
    => base.Encode(model)
      .AddMap("categories", model.GetCategories(default), _categories.I, "_Categories")
      .AddMap("directives", model.GetDirectives(default), _directives.I, "_Directives")
      .AddMap("types", model.GetTypes(default), _types.I, "_Type")
      .AddMap("settings", model.GetSettings(default), _settings.I, "_Setting")
      .Add("_errors", model.Errors.Encode());

  internal static new SchemaEncoder Factory(IEncoderRepository r) => new(r);
}
