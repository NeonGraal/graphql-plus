namespace GqlPlus.Rendering.Objects;

public class InputFieldRendererTests
  : ObjectBaseRendererBase<InputFieldModel, InputBaseModel>
{
  private readonly IRenderer<ModifierModel> _modifer;
  private readonly IRenderer<ConstantModel> _constant;

  public InputFieldRendererTests()
  {
    _modifer = RFor<ModifierModel>();
    _constant = RFor<ConstantModel>();

    Renderer = new InputFieldRenderer(_constant, new(_modifer, ObjBase));
  }

  protected override IRenderer<InputFieldModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string input, string contents)
  {
    // Arrange
    InputBaseModel inputBase = new(input, "");
    ObjBase.Render(inputBase).Returns(new Structured(input));

    // Act & Accept
    RenderAndCheck(new(name, inputBase, contents), [
      "!_InputField",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "type: " + input
      ]);
  }
}
