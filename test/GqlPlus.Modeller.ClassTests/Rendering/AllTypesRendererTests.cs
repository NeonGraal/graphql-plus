namespace GqlPlus.Rendering;

public class AllTypesRendererTests
  : RendererClassTestBase<BaseTypeModel>
{
  private readonly ITypeRenderer _typeRenderer;

  public AllTypesRendererTests()
  {
    _typeRenderer = For<ITypeRenderer>();
    Renderer = new AllTypesRenderer([_typeRenderer]);
  }

  protected override IRenderer<BaseTypeModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithMatchingTypeRenderer_ReturnsStructured(string type)
  {
    // Arrange
    SpecialTypeModel model = new(type, "");
    _typeRenderer.ForType(model).Returns(true);
    Structured expectedStructured = new(type);
    _typeRenderer.TypeRender(model).Returns(expectedStructured);

    // Act
    RenderAndCheck(model, [type]);
  }

  [Fact]
  public void Render_WithNoMatchingTypeRenderer_ThrowsInvalidOperationException()
  {
    // Arrange
    SpecialTypeModel model = new("", "");
    _typeRenderer.ForType(model).Returns(false);

    // Act
    void Result() => Renderer.Render(model);

    // Assert
    Should.Throw<InvalidOperationException>(Result)
        .Message.ShouldContain("Unable to find Renderer for");
  }
}
