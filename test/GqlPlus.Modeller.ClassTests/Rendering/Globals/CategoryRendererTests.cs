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
    _output.Render(output).Returns(new Structured(outputName, "Output"));
    _modifiers.Render(modifier).Returns(new Structured("List"));

    // Act
    RenderAndCheck(new(name, output, contents) {
      Modifiers = [modifier],
    }, [
        "!_Category",
        "description: " + contents.Quoted("'"),
        "modifiers: [List]",
        "name: " + name,
        "output: !Output " + outputName,
        "resolution: !_Resolution Parallel"
        ]);
  }
}
