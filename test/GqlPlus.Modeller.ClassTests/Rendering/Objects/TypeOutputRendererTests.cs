namespace GqlPlus.Rendering.Objects;

public class TypeOutputRendererTests
  : TypeObjectRendererBase<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>
{
  public TypeOutputRendererTests()
    => Renderer = new TypeOutputRenderer(new(Base, Field, ObjField, DualField, Alternate, ObjAlternate, DualAlternate, TypeParam));

  protected override IRenderer<TypeOutputModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_TypeOutput",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Output"
      ]);
}
