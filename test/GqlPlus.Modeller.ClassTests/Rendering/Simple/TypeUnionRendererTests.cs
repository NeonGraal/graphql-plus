namespace GqlPlus.Rendering.Simple;

public class TypeUnionRendererTests
  : RendererClassTestBase<TypeUnionModel>
{
  private readonly IRenderer<TypeRefModel<SimpleKindModel>> _parent;
  private readonly IRenderer<AliasedModel> _item;
  private readonly IRenderer<UnionMemberModel> _all;

  public TypeUnionRendererTests()
  {
    _parent = RFor<TypeRefModel<SimpleKindModel>>();
    _item = RFor<AliasedModel>();
    _all = RFor<UnionMemberModel>();

    Renderer = new TypeUnionRenderer(new(_parent, _item, _all));
  }

  protected override IRenderer<TypeUnionModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_TypeUnion",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Union"
    ]);
}
