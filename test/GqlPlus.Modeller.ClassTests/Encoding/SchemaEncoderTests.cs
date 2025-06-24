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
    => EncodeAndCheck(new(name, contents), [
      "!_Schema",
      "description: " + contents.Quoted("'"),
      "name: " + name
      ]);

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
    ITokenMessages? errors = new TokenMessages(new TokenMessage(AstNulls.At, errorMessage));
    SchemaModel model = new(name, categories, directives, settings, types, errors) {
      Aliases = aliases
    };

    EncodeReturns(_categories, Arg.Any<CategoriesModel>(), new Structured(categoryName, "_Categories"));
    EncodeReturns(_directives, Arg.Any<DirectivesModel>(), new Structured(directiveName, "_Directives"));
    EncodeReturns(_settings, Arg.Any<SettingModel>(), new Structured(settingName, "_Setting"));
    EncodeReturns(_types, Arg.Any<BaseTypeModel>(), new Structured(typeName, "_TypeOutput"));

    EncodeAndCheck(model, [
        "!_Schema",
        "_errors:", "  - !_Error",
        "    _kind: !_TokenKind Start", "    _message: " + errorMessage,
        "aliases: " + aliases.Surround("[","]",","),
        "categories: !_Map_Categories", $"  !_Identifier {categoryName}: !_Categories {categoryName}",
        "directives: !_Map_Directives", $"  !_Identifier {directiveName}: !_Directives {directiveName}",
        "name: " + name,
        "settings: !_Map_Setting", $"  !_Identifier {settingName}: !_Setting {settingName}",
        "types: !_Map_Type", $"  !_Identifier {typeName}: !_TypeOutput {typeName}"
      ]);
  }
}
