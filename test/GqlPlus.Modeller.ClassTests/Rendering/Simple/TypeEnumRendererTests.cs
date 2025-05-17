namespace GqlPlus.Rendering.Simple;

public class TypeEnumRendererTests
  : RendererClassTestBase<TypeEnumModel>
{
  private readonly ParentTypeRenderers<AliasedModel, EnumLabelModel> _renderers;

  public TypeEnumRendererTests()
  {
    IRenderer<TypeRefModel<SimpleKindModel>> parent = RFor<TypeRefModel<SimpleKindModel>>();
    IRenderer<AliasedModel> item = RFor<AliasedModel>();
    IRenderer<EnumLabelModel> all = RFor<EnumLabelModel>();

    _renderers = new ParentTypeRenderers<AliasedModel, EnumLabelModel>(parent, item, all);
    Renderer = new TypeEnumRenderer(_renderers);
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
