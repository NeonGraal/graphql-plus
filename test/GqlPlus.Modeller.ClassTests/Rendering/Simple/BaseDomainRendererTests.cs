namespace GqlPlus.Rendering.Simple;

public class BaseDomainRendererTests
  : RendererClassTestBase<BaseDomainModel<DomainLabelModel>>
{
  private readonly ParentTypeRenderers<DomainLabelModel, DomainItemModel<DomainLabelModel>> _renderers;

  public BaseDomainRendererTests()
  {
    IRenderer<TypeRefModel<SimpleKindModel>> parent = RFor<TypeRefModel<SimpleKindModel>>();
    IRenderer<DomainLabelModel> item = RFor<DomainLabelModel>();
    IRenderer<DomainItemModel<DomainLabelModel>> all = RFor<DomainItemModel<DomainLabelModel>>();
    _renderers = new ParentTypeRenderers<DomainLabelModel, DomainItemModel<DomainLabelModel>>(parent, item, all);

    Renderer = new BaseDomainRenderer<DomainLabelModel>(_renderers);
  }

  protected override IRenderer<BaseDomainModel<DomainLabelModel>> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(DomainKindModel.Enum, name, contents), [
      "!_DomainEnum",
      "description: " + contents.Quoted("'"),
      "domainKind: !_DomainKind Enum",
      "name: " + name,
      "typeKind: !_TypeKind Domain"
      ]);
}
