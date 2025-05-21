namespace GqlPlus.Rendering.Objects;

public class TypeInputRendererTests
  : TypeObjectRendererBase<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>
{
  public TypeInputRendererTests()
    => Renderer = new TypeInputRenderer(new(Base, Field, ObjField, DualField, Alternate, ObjAlternate, DualAlternate, TypeParam));

  protected override IRenderer<TypeInputModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_TypeInput",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Input"
      ]);
}
