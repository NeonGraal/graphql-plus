namespace GqlPlus.Encoding;

internal class SchemaEncoder(
  IEncoderRepository encoders
) : AliasedEncoder<SchemaModel>
{
  private readonly IEncoder<CategoriesModel> _categories = encoders.EncoderFor<CategoriesModel>();
  private readonly IEncoder<DirectivesModel> _directives = encoders.EncoderFor<DirectivesModel>();
  private readonly IEncoder<OperationsModel> _operations = encoders.EncoderFor<OperationsModel>();
  private readonly IEncoder<BaseTypeModel> _types = encoders.EncoderFor<BaseTypeModel>();
  private readonly IEncoder<SettingModel> _settings = encoders.EncoderFor<SettingModel>();

  internal override Structured Encode(SchemaModel model)
    => base.Encode(model)
      .AddMap("categories", model.GetCategories(default), _categories, "_Categories")
      .AddMap("directives", model.GetDirectives(default), _directives, "_Directives")
      .AddMap("operations", model.GetOperations(default), _operations, "_Operations")
      .AddMap("types", model.GetTypes(default), _types, "_Type")
      .AddMap("settings", model.GetSettings(default), _settings, "_Setting")
      .Add("_errors", model.Errors.Encode());
}
