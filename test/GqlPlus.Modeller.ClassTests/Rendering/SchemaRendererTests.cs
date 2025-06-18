using GqlPlus.Ast;
using GqlPlus.Token;
using GqlPlus.Modelling;

namespace GqlPlus.Rendering;

public class SchemaRendererTests
  : RendererClassTestBase<SchemaModel>
{
  private readonly IRenderer<CategoriesModel> _categories;
  private readonly IRenderer<DirectivesModel> _directives;
  private readonly IRenderer<BaseTypeModel> _types;
  private readonly IRenderer<OperationsModel> _operations;
  private readonly IRenderer<SettingModel> _settings;

  public SchemaRendererTests()
  {
    _categories = RFor<CategoriesModel>();
    _directives = RFor<DirectivesModel>();
    _types = RFor<BaseTypeModel>();
    _operations = RFor<OperationsModel>();
    _settings = RFor<SettingModel>();

    Renderer = new SchemaRenderer(_categories, _directives, _operations, _settings, _types);
  }

  protected override IRenderer<SchemaModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_Schema",
      "description: " + contents.Quoted("'"),
      "name: " + name
      ]);

  [Theory, RepeatData]
  public void Render_WithAll_ReturnsExpected(
    string name,
    string[] aliases,
    string categoryName,
    string directiveName,
    string operationName,
    string settingName,
    string typeName,
    string errorMessage)
  {
    IEnumerable<CategoryModel> categories = [new(categoryName, new(TypeKindModel.Output, typeName, ""), "")];
    IEnumerable<DirectiveModel> directives = [new(directiveName, "")];
    IEnumerable<OperationModel> operations = [new(operationName, "", "", "")];
    IEnumerable<SettingModel> settings = [new(settingName, null!, "")];
    IEnumerable<TypeOutputModel> types = [new(typeName, "")];
    ITokenMessages? errors = new TokenMessages(new TokenMessage(AstNulls.At, errorMessage));
    SchemaModel model = new(name, categories, directives, operations, settings, types, errors) {
      Aliases = aliases
    };

    RenderReturns(_categories, Arg.Any<CategoriesModel>(), new Structured(categoryName, "_Categories"));
    RenderReturns(_directives, Arg.Any<DirectivesModel>(), new Structured(directiveName, "_Directives"));
    RenderReturns(_operations, Arg.Any<OperationsModel>(), new Structured(operationName, "_Operations"));
    RenderReturns(_settings, Arg.Any<SettingModel>(), new Structured(settingName, "_Setting"));
    RenderReturns(_types, Arg.Any<BaseTypeModel>(), new Structured(typeName, "_TypeOutput"));

    RenderAndCheck(model, [
        "!_Schema",
        "_errors:", "  - !_Error",
        "    _kind: !_TokenKind Start", "    _message: " + errorMessage,
        "aliases: " + aliases.Surround("[","]",","),
        "categories: !_Map_Categories", $"  !_Identifier {categoryName}: !_Categories {categoryName}",
        "directives: !_Map_Directives", $"  !_Identifier {directiveName}: !_Directives {directiveName}",
        "name: " + name,
        "operations: !_Map_Operations", $"  !_Identifier {operationName}: !_Operations {operationName}",
        "settings: !_Map_Setting", $"  !_Identifier {settingName}: !_Setting {settingName}",
        "types: !_Map_Type", $"  !_Identifier {typeName}: !_TypeOutput {typeName}"
      ]);
  }
}
