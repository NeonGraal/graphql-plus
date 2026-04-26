namespace GqlPlus.Modelling.Globals;

public class CategoryModellerTests
  : ModellerClassTestBase<IAstSchemaCategory, CategoryModel>
{
  private readonly IModeller<IAstModifier, ModifierModel> _modifier = MFor<IAstModifier, ModifierModel>();

  public CategoryModellerTests()
  {
    IModellerRepository modellers = A.Of<IModellerRepository>();
    modellers.ModellerFor<IAstModifier, ModifierModel>().Returns(_modifier);
    Modeller = new CategoryModeller(modellers);
  }

  protected override IModeller<IAstSchemaCategory, CategoryModel> Modeller { get; }

  [Theory, RepeatData]
  public void ToModel_WithValidCategory_ReturnsExpectedCategoryModel(string categoryName, string outputName, string contents)
  {
    // Arrange
    IAstSchemaCategory ast = A.Named<IAstSchemaCategory>(categoryName, contents);
    IAstTypeRef output = A.Named<IAstTypeRef>(outputName);
    ast.Output.Returns(output);
    ast.CategoryOption.Returns(CategoryOption.Parallel);
    IEnumerable<IAstModifier> modifiers = [A.Modifier(ModifierKind.List), A.Modifier(ModifierKind.Opt)];
    ast.Modifiers.Returns(modifiers);

    _modifier.ToModels(modifiers, TypeKinds)
      .Returns([new ModifierModel(ModifierKindModel.List), new ModifierModel(ModifierKindModel.Opt)]);

    // Act
    CategoryModel result = Modeller.ToModel(ast, TypeKinds);

    // Assert
    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(categoryName),
        r => r.Output.Name.ShouldBe(outputName),
        r => r.Description.ShouldBe(contents),
        r => r.Resolution.ShouldBe(CategoryOptionModel.Parallel)
      );
  }
}
