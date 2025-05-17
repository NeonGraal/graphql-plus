namespace GqlPlus.Rendering.Globals;

public class SettingRendererTests
  : RendererClassTestBase<SettingModel>
{
  public SettingRendererTests()
  {
    _constant = RFor<ConstantModel>();
    Renderer = new SettingRenderer(_constant);
  }

  private readonly IRenderer<ConstantModel> _constant;

  protected override IRenderer<SettingModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidSettingModel_ReturnsStructured(string name, string value)
  {
    // Arrange
    SimpleModel simple = SimpleModel.Str("", value);
    ConstantModel constant = new(simple);
    _constant.Render(constant).Returns(new Structured(value));

    // Act
    RenderAndCheck(new(name, constant, ""), [
        "!_Setting",
        "name: " + name,
        "value: " + value,
        ]);
  }
}
