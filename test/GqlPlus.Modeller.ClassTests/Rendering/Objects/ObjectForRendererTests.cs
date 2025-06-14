namespace GqlPlus.Rendering.Objects;

public class ObjectForRendererTests
  : RendererClassTestBase<ObjectForModel<TypeParamModel>>
{
  private readonly IRenderer<TypeParamModel> _typeParam;

  public ObjectForRendererTests()
  {
    _typeParam = RFor<TypeParamModel>();

    Renderer = new ObjectForRenderer<TypeParamModel>(_typeParam);
  }

  protected override IRenderer<ObjectForModel<TypeParamModel>> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string input, string name)
  {
    RenderReturnsMap(_typeParam, "_TypeParam", input);

    RenderAndCheck(new(new(input, ""), name),
      ["!_ObjectFor(_TypeParam)",
        "object: " + name,
        $"value: !_TypeParam '{input}'"
        ]);
  }
}
