using GqlPlus.Ast.Schema;
using GqlPlus.Resolving;

namespace GqlPlus.Modelling;

public class SchemaModellerTests
  : ModellerClassTestBase<IAstSchema, SchemaModel>
{
  private readonly IModeller<IAstSchemaCategory, CategoryModel> _category = MFor<IAstSchemaCategory, CategoryModel>();
  private readonly IModeller<IAstSchemaDirective, DirectiveModel> _directive = MFor<IAstSchemaDirective, DirectiveModel>();
  private readonly IModeller<IAstSchemaOperation, OperationModel> _operation = MFor<IAstSchemaOperation, OperationModel>();
  private readonly IModeller<IAstSchemaSetting, SettingModel> _setting = MFor<IAstSchemaSetting, SettingModel>();
  private readonly ITypesModeller _types = A.Of<ITypesModeller>();

  public SchemaModellerTests()
  {
    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModellerFor<IAstSchemaCategory, CategoryModel>().Returns(_category);
    modellers.ModellerFor<IAstSchemaDirective, DirectiveModel>().Returns(_directive);
    modellers.ModellerFor<IAstSchemaOperation, OperationModel>().Returns(_operation);
    modellers.ModellerFor<IAstSchemaSetting, SettingModel>().Returns(_setting);
    modellers.TypesModeller.Returns(_types);
    Modeller = new SchemaModeller(modellers);
  }

  protected override IModeller<IAstSchema, SchemaModel> Modeller { get; }

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
    IAstSchemaCategory category = A.Named<IAstSchemaCategory>(categoryName, string.Empty);
    IAstSchemaDirective directive = A.Named<IAstSchemaDirective>(directiveName, string.Empty);
    IAstSchemaOption option = A.Aliased<IAstSchemaOption>(name, aliases, contents);
    IAstSchemaSetting setting = A.Named<IAstSchemaSetting>(settingName, string.Empty);
    option.Settings.Returns([setting]);
    IAstType type = A.Named<IAstType>(typeName, string.Empty);

    IAstSchema ast = A.Error<IAstSchema>();
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
