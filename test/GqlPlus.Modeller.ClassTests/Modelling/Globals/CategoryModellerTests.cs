namespace GqlPlus.Modelling.Globals;

public class CategoryModellerTests
  : ModellerClassTestBase<IGqlpSchemaCategory, CategoryModel>
{
  public CategoryModellerTests()
  {
    IModeller<IGqlpModifier, ModifierModel> modifier = For<IModeller<IGqlpModifier, ModifierModel>>();

    Modeller = new CategoryModeller(modifier);
  }

  protected override IModeller<IGqlpSchemaCategory, CategoryModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidCategory_ReturnsExpectedCategoryModel(string categoryName, string outputName, string contents)
  {
    // Arrange
    IGqlpSchemaCategory ast = For<IGqlpSchemaCategory>();
    ast.Name.Returns(categoryName);
    IGqlpTypeRef output = NFor<IGqlpTypeRef>(outputName);
    ast.Output.Returns(output);
    ast.Description.Returns(contents);
    ast.CategoryOption.Returns(CategoryOption.Parallel);

    // Act
    CategoryModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Name.ShouldBe(categoryName);
    result.Output.Name.ShouldBe(outputName);
    result.Description.ShouldBe(contents);
    result.Resolution.ShouldBe(CategoryOption.Parallel);
  }
}
