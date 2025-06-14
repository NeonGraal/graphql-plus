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
  public void Render_WithValidModel_ReturnsStructured(string input, string contents, string typeName)
  {
    TypeRefModel<TypeKindModel> typeRef = new(TypeKindModel.Special, typeName, "");

    RenderReturnsMap(_typeKind, "_TypeRef", typeName);

    RenderAndCheck(new(input, contents, typeRef),
      ["!_TypeParam",
        "constraint:", $"  value: !_TypeRef '{typeName}'",
        "description: " + contents.Quoted("'"),
        "name: " + input
        ]);
  }
}
