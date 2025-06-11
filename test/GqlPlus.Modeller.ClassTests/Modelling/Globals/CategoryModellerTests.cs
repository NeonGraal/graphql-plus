namespace GqlPlus.Modelling.Globals;

public class CategoryModellerTests
  : ModellerClassTestBase<IGqlpSchemaCategory, CategoryModel>
{
  public CategoryModellerTests()
  {
    IModeller<IGqlpModifier, ModifierModel> modifier = MFor<IGqlpModifier, ModifierModel>();

    Modeller = new CategoryModeller(modifier);
  }

  protected override IModeller<IGqlpSchemaCategory, CategoryModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidCategory_ReturnsExpectedCategoryModel(string categoryName, string outputName, string contents)
  {
    // Arrange
    IGqlpSchemaCategory ast = A.Named<IGqlpSchemaCategory>(categoryName);
    IGqlpTypeRef output = A.Named<IGqlpTypeRef>(outputName);
    ast.Output.Returns(output);
    ast.Description.Returns(contents);
    ast.CategoryOption.Returns(CategoryOption.Parallel);

    // Act
    CategoryModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(categoryName),
        r => r.Output.TypeName.ShouldBe(outputName),
        r => r.Description.ShouldBe(contents),
        r => r.Resolution.ShouldBe(CategoryOption.Parallel)
      );
  }
}
