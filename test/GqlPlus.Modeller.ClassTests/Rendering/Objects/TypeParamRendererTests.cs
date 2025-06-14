namespace GqlPlus.Rendering.Objects;

public class TypeParamRendererTests
  : RendererClassTestBase<TypeParamModel>
{
  private readonly IRenderer<TypeRefModel<TypeKindModel>> _typeKind;

  public TypeParamRendererTests()
  {
    _typeKind = RFor<TypeRefModel<TypeKindModel>>();

    Renderer = new TypeParamRenderer(_typeKind);
  }

  protected override IRenderer<TypeParamModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string input, string contents)
    => RenderAndCheck(new(input, contents), [
      "!_TypeParam",
      "description: " + contents.Quoted("'"),
      "name: " + input
      ]);
}
