namespace GqlPlus.Rendering.Objects;

public class TypeDualRendererTests
  : TypeObjectRendererBase<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>
{
  public TypeDualRendererTests()
    => Renderer = new TypeDualRenderer(new(ObjBase, Field, ObjField, DualField, Alternate, ObjAlternate, DualAlternate, TypeParam));

  protected override IRenderer<TypeDualModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_TypeDual",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Dual"
      ]);
}
