namespace GqlPlus.Modelling;

public class SchemaModellerTests
  : ModellerClassTestBase
{
  private readonly SchemaModeller _sut;

  public SchemaModellerTests()
  {
    IModeller<IGqlpSchemaCategory, CategoryModel> category = For<IModeller<IGqlpSchemaCategory, CategoryModel>>();
    IModeller<IGqlpSchemaDirective, DirectiveModel> directive = For<IModeller<IGqlpSchemaDirective, DirectiveModel>>();
    IModeller<IGqlpSchemaSetting, SettingModel> setting = For<IModeller<IGqlpSchemaSetting, SettingModel>>();
    ITypesModeller types = For<ITypesModeller>();
    _sut = new SchemaModeller(category, directive, setting, types);
  }

  [Fact]
  public void ToModel_WithValidSchema_ReturnsExpectedSchemaModel()
  {
    // Arrange
    IGqlpSchema ast = For<IGqlpSchema>();
    ast.Declarations.Returns([]);

    // Act
    SchemaModel result = _sut.ToModel<SchemaModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<SchemaModel>();
  }
}
