namespace GqlPlus.Modelling;

public class SchemaModellerTests
  : ModellerClassTestBase<IGqlpSchema, SchemaModel>
{
  public SchemaModellerTests()
  {
    IModeller<IGqlpSchemaCategory, CategoryModel> category = For<IModeller<IGqlpSchemaCategory, CategoryModel>>();
    IModeller<IGqlpSchemaDirective, DirectiveModel> directive = For<IModeller<IGqlpSchemaDirective, DirectiveModel>>();
    IModeller<IGqlpSchemaSetting, SettingModel> setting = For<IModeller<IGqlpSchemaSetting, SettingModel>>();
    ITypesModeller types = For<ITypesModeller>();

    Modeller = new SchemaModeller(category, directive, setting, types);
  }

  protected override IModeller<IGqlpSchema, SchemaModel> Modeller { get; }

  [Fact]
  public void ToModel_WithValidSchema_ReturnsExpectedSchemaModel()
  {
    // Arrange
    IGqlpSchema ast = For<IGqlpSchema>();
    ast.Declarations.Returns([]);

    // Act
    SchemaModel result = Modeller.ToModel<SchemaModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<SchemaModel>();
  }
}
