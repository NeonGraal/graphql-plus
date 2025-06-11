namespace GqlPlus.Modelling;

public class SchemaModellerTests
  : ModellerClassTestBase<IGqlpSchema, SchemaModel>
{
  public SchemaModellerTests()
  {
    IModeller<IGqlpSchemaCategory, CategoryModel> category = MFor<IGqlpSchemaCategory, CategoryModel>();
    IModeller<IGqlpSchemaDirective, DirectiveModel> directive = MFor<IGqlpSchemaDirective, DirectiveModel>();
    IModeller<IGqlpSchemaSetting, SettingModel> setting = MFor<IGqlpSchemaSetting, SettingModel>();
    ITypesModeller types = A.Of<ITypesModeller>();

    Modeller = new SchemaModeller(category, directive, setting, types);
  }

  protected override IModeller<IGqlpSchema, SchemaModel> Modeller { get; }

  [Fact]
  public void ToModel_WithValidSchema_ReturnsExpectedSchemaModel()
  {
    // Arrange
    IGqlpSchema ast = A.Of<IGqlpSchema>();
    ast.Declarations.Returns([]);

    // Act
    SchemaModel result = Modeller.ToModel<SchemaModel>(ast, TypeKinds);

    // Assert
    result.ShouldBeOfType<SchemaModel>();
  }
}
