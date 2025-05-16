using GqlPlus;

namespace GqlPlus.Rendering.Globals;

public class CategoryRendererTests
  : RendererClassTestBase<CategoryModel>
{
  private readonly IRenderer<ModifierModel> _modifiers;
  private readonly IRenderer<TypeRefModel<TypeKindModel>> _output;

  public CategoryRendererTests()
  {
    _modifiers = RFor<ModifierModel>();
    _output = RFor<TypeRefModel<TypeKindModel>>();
    Renderer = new CategoryRenderer(_modifiers, _output);
  }

  protected override IRenderer<CategoryModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidCategoryModel_ReturnsStructured(string name, string outputName, string contents)
  {
    // Arrange
    TypeRefModel<TypeKindModel> output = new(TypeKindModel.Output, outputName, "");
    ModifierModel modifier = new(ModifierKind.List);
    CategoryModel model = new(name, output, contents) {
      Modifiers = [modifier],
    };
    _output.Render(output).Returns(new Structured(outputName, "Output"));
    _modifiers.Render(modifier).Returns(new Structured("List"));

    // Act
    Structured result = Renderer.Render(model);

    // Assert
    result.ShouldNotBeNull()
      .ToLines(false).ToLines()
      .ShouldBe([
        "!_Category",
        "description: " + contents.Quoted("'"),
        "modifiers: [List]",
        "name: " + name,
        "output: !Output " + outputName,
        "resolution: !_Resolution Parallel"
        ]);
  }
}
