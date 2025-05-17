namespace GqlPlus.Rendering.Simple;

public class TypeEnumRendererTests
  : RendererClassTestBase<TypeEnumModel>
{
  private readonly IRenderer<TypeRefModel<SimpleKindModel>> _parent;
  private readonly IRenderer<AliasedModel> _item;
  private readonly IRenderer<EnumLabelModel> _all;

  public TypeEnumRendererTests()
  {
    _parent = RFor<TypeRefModel<SimpleKindModel>>();
    _item = RFor<AliasedModel>();
    _all = RFor<EnumLabelModel>();

    Renderer = new TypeEnumRenderer(new(_parent, _item, _all));
  }

  protected override IRenderer<TypeEnumModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_TypeEnum",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Enum"
    ]);
}
