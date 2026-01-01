using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Encoding;

public class SchemaEncoderTests
  : EncoderClassTestBase<SchemaModel>
{
  private readonly IEncoder<CategoriesModel> _categories;
  private readonly IEncoder<DirectivesModel> _directives;
  private readonly IEncoder<BaseTypeModel> _types;
  private readonly IEncoder<SettingModel> _settings;

  public SchemaEncoderTests()
  {
    _categories = RFor<CategoriesModel>();
    _directives = RFor<DirectivesModel>();
    _types = RFor<BaseTypeModel>();
    _settings = RFor<SettingModel>();

    Encoder = new SchemaEncoder(_categories, _directives, _types, _settings);
  }

  protected override IEncoder<SchemaModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string contents)
    => EncodeAndCheck(new(name, contents),
      TagAll("_Schema",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + name));

  [Theory, RepeatData]
  public void Encode_WithAll_ReturnsExpected(
    string name,
    string[] aliases,
    string categoryName,
    string directiveName,
    string settingName,
    string typeName,
    string errorMessage)
  {
    IEnumerable<CategoryModel> categories = [new(categoryName, new(TypeKindModel.Output, typeName, ""), "")];
    IEnumerable<DirectiveModel> directives = [new(directiveName, "")];
    IEnumerable<SettingModel> settings = [new(settingName, null!, "")];
    IEnumerable<TypeOutputModel> types = [new(typeName, "")];
    IMessages? errors = new Messages(new TokenMessage(AstNulls.At, errorMessage));
    SchemaModel model = new(name, categories, directives, settings, types, errors) {
      Aliases = aliases
    };

    EncodeReturns(_categories, Arg.Any<CategoriesModel>(), new Structured(categoryName, "_Categories"));
    EncodeReturns(_directives, Arg.Any<DirectivesModel>(), new Structured(directiveName, "_Directives"));
    EncodeReturns(_settings, Arg.Any<SettingModel>(), new Structured(settingName, "_Setting"));
    EncodeReturns(_types, Arg.Any<BaseTypeModel>(), new Structured(typeName, "_TypeOutput"));

    IEnumerable<string> taggedAliases = aliases.Select((s, i) => $":aliases.{i}={s}");

    EncodeAndCheck(model, TagAll("_Schema", [
        ":_errors[_Errors].0[_Error]:_kind=[_TokenKind]Start",
        ":_errors[_Errors].0[_Error]:_message=" + errorMessage,
        .. taggedAliases,
        $":categories[_Map(_Categories)]:[_Name]{categoryName}=[_Categories]{categoryName}",
        $":directives[_Map(_Directives)]:[_Name]{directiveName}=[_Directives]{directiveName}",
        ":name=" + name,
        $":settings[_Map(_Setting)]:[_Name]{settingName}=[_Setting]{settingName}",
        $":types[_Map(_Type)]:[_Name]{typeName}=[_TypeOutput]{typeName}"]));
  }
}
