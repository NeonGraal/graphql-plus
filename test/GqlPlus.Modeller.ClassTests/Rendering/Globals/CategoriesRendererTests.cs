namespace GqlPlus.Rendering.Globals;

public class CategoriesRendererTests
  : RendererClassTestBase<CategoriesModel>
{
  private readonly IRenderer<CategoryModel> _category;
  private readonly IRenderer<BaseTypeModel> _baseType;

  public CategoriesRendererTests()
  {
    _category = RFor<CategoryModel>();
    _baseType = RFor<BaseTypeModel>();
    Renderer = new CategoriesRenderer(new(_category, _baseType));
  }

  protected override IRenderer<CategoriesModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidCategoriesModel_ReturnsStructured(string name)
  {
    // Arrange
    BaseTypeModel type = new TypeInputModel(name, "");
    CategoryModel category = new(name, new(TypeKindModel.Output, name, ""), "");
    _baseType.Render(type).Returns(new Structured(name, "Input"));
    _category.Render(category).Returns(new Structured(name, "Category"));

    // Act
    RenderAndCheck(new() {
      Type = type,
      And = category
    }, [
        "!_Categories",
        "category: !Category " + name,
        "type: !Input " + name
        ]);
  }
}
