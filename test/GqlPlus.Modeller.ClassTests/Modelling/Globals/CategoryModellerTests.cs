namespace GqlPlus.Modelling.Globals;

public class CategoryModellerTests
  : ModellerClassTestBase<IGqlpSchemaCategory, CategoryModel>
{
  private readonly IModeller<IGqlpModifier, ModifierModel> _modifier = MFor<IGqlpModifier, ModifierModel>();

  public CategoryModellerTests()
    => Modeller = new CategoryModeller(_modifier);

  protected override IModeller<IGqlpSchemaCategory, CategoryModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidCategory_ReturnsExpectedCategoryModel(string categoryName, string outputName, string contents)
  {
    // Arrange
    IGqlpSchemaCategory ast = A.Named<IGqlpSchemaCategory>(categoryName, contents);
    IGqlpTypeRef output = A.Named<IGqlpTypeRef>(outputName);
    ast.Output.Returns(output);
    ast.CategoryOption.Returns(CategoryOption.Parallel);
    IEnumerable<IGqlpModifier> modifiers = [A.Modifier(ModifierKind.List), A.Modifier(ModifierKind.Opt)];
    ast.Modifiers.Returns(modifiers);

    _modifier.ToModels(modifiers, TypeKinds)
      .Returns([new ModifierModel(ModifierKind.List), new ModifierModel(ModifierKind.Opt)]);

    // Act
    CategoryModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(categoryName),
        r => r.Output.Name.ShouldBe(outputName),
        r => r.Description.ShouldBe(contents),
        r => r.Resolution.ShouldBe(CategoryOption.Parallel)
      );
  }
}
