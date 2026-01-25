using GqlPlus.Resolving;

namespace GqlPlus.Modelling;

public class SchemaModellerTests
  : ModellerClassTestBase<IGqlpSchema, SchemaModel>
{
  private readonly IModeller<IGqlpSchemaCategory, CategoryModel> _category = MFor<IGqlpSchemaCategory, CategoryModel>();
  private readonly IModeller<IGqlpSchemaDirective, DirectiveModel> _directive = MFor<IGqlpSchemaDirective, DirectiveModel>();
  private readonly IModeller<IGqlpSchemaSetting, SettingModel> _setting = MFor<IGqlpSchemaSetting, SettingModel>();
  private readonly ITypesModeller _types = A.Of<ITypesModeller>();

  public SchemaModellerTests()
    => Modeller = new SchemaModeller(_category, _directive, _setting, _types);

  protected override IModeller<IGqlpSchema, SchemaModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidSchema_ReturnsExpectedSchemaModel(
    string name,
    string[] aliases,
    string contents,
    string categoryName,
    string directiveName,
    string settingName,
    string typeName)
  {
    // Arrange
    IGqlpSchemaCategory category = A.Named<IGqlpSchemaCategory>(categoryName, string.Empty);
    IGqlpSchemaDirective directive = A.Named<IGqlpSchemaDirective>(directiveName, string.Empty);
    IGqlpSchemaOption option = A.Aliased<IGqlpSchemaOption>(name, aliases, contents);
    IGqlpSchemaSetting setting = A.Named<IGqlpSchemaSetting>(settingName, string.Empty);
    option.Settings.Returns([setting]);
    IGqlpType type = A.Named<IGqlpType>(typeName, string.Empty);

    IGqlpSchema ast = A.Error<IGqlpSchema>();
    ast.Declarations.Returns([category, directive, option, type]);

    CategoryModel categoryModel = new(categoryName, new(TypeKindModel.Output, typeName, string.Empty), string.Empty);
    ToModelReturns(_category, categoryModel);
    DirectiveModel directiveModel = new(directiveName, string.Empty);
    ToModelReturns(_directive, directiveModel);
    SettingModel settingModel = new(settingName, new(SimpleModel.Str("value")), string.Empty);
    ToModelsReturns(_setting, [settingModel]);
    SpecialTypeModel typeModel = new(typeName, contents);
    ToModelReturns(_types, typeModel);

    ModelsContext context = [];

    // Act
    SchemaModel result = Modeller.ToModel<SchemaModel>(ast, context);

    // Assert
    result.ShouldBeOfType<SchemaModel>()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Aliases.ShouldBe(aliases),
        r => r.Categories.ShouldContainKeyAndValue(categoryName, categoryModel),
        r => r.Directives.ShouldContainKeyAndValue(directiveName, directiveModel),
        r => r.Settings.ShouldContainKeyAndValue(settingName, settingModel),
        r => r.Types.ShouldContainKeyAndValue(typeName, typeModel)
      );
  }
}
