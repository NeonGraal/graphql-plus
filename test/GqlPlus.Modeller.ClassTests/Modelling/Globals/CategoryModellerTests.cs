namespace GqlPlus.Modelling.Globals;

public class CategoryModellerTests
  : ModellerClassTestBase
{
  private readonly CategoryModeller _modeller;

  public CategoryModellerTests()
  {
    IModeller<IGqlpModifier, ModifierModel> modifier = For<IModeller<IGqlpModifier, ModifierModel>>();

    _modeller = new CategoryModeller(modifier);
  }

  [Theory, RepeatData]
  public void ToModel_WithValidCategory_ReturnsExpectedCategoryModel(string outputName)
  {
    // Arrange
    IGqlpSchemaCategory ast = For<IGqlpSchemaCategory>();
    ast.Name.Returns("CategoryName");
    IGqlpTypeRef output = NFor<IGqlpTypeRef>(outputName);
    ast.Output.Returns(output);
    ast.Description.Returns("Category description");
    ast.CategoryOption.Returns(CategoryOption.Parallel);

    // Act
    CategoryModel result = _modeller.ToModel<CategoryModel>(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull();
    result.Name.ShouldBe("CategoryName");
    result.Output.Name.ShouldBe(outputName);
    result.Description.ShouldBe("Category description");
    result.Resolution.ShouldBe(CategoryOption.Parallel);
  }
}
