namespace GqlPlus.Rendering.Simple;

public class BaseDomainRendererTests
  : RendererClassTestBase<BaseDomainModel<DomainLabelModel>>
{
  private readonly IRenderer<TypeRefModel<SimpleKindModel>> _parent;
  private readonly IRenderer<DomainLabelModel> _item;
  private readonly IRenderer<DomainItemModel<DomainLabelModel>> _all;

  public BaseDomainRendererTests()
  {
    _parent = RFor<TypeRefModel<SimpleKindModel>>();
    _item = RFor<DomainLabelModel>();
    _all = RFor<DomainItemModel<DomainLabelModel>>();

    Renderer = new BaseDomainRenderer<DomainLabelModel>(new(_parent, _item, _all));
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
