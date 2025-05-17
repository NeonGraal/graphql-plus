namespace GqlPlus.Rendering.Simple;

public class TypeUnionRendererTests
  : RendererClassTestBase<TypeUnionModel>
{
  private readonly ParentTypeRenderers<AliasedModel, UnionMemberModel> _renderers;

  public TypeUnionRendererTests()
  {
    IRenderer<TypeRefModel<SimpleKindModel>> parent = RFor<TypeRefModel<SimpleKindModel>>();
    IRenderer<AliasedModel> item = RFor<AliasedModel>();
    IRenderer<UnionMemberModel> all = RFor<UnionMemberModel>();

    _renderers = new ParentTypeRenderers<AliasedModel, UnionMemberModel>(parent, item, all);
    Renderer = new TypeUnionRenderer(_renderers);
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
