namespace GqlPlus.Rendering.Simple;

public abstract class DomainRendererTestBase<TItem, TInput>
  : ParentTypeRendererClassTestBase<BaseDomainModel<TItem>, TItem, DomainItemModel<TItem>, TInput>
  where TItem : BaseDomainItemModel
{
  protected DomainRendererTestBase()
    => Renderer = new BaseDomainRenderer<TItem>(Renderers);

  protected override IRenderer<BaseDomainModel<TItem>> Renderer { get; }
  protected override SimpleKindModel Kind => SimpleKindModel.Domain;

  protected override BaseDomainModel<TItem> NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent)
    => new(DomainKind, name, contents) { Parent = parent };
  protected override DomainItemModel<TItem> NewAll(TInput item, string name) => new(NewItem(item), name);
  protected override string[] ValidModelExpected(string name, string parent, string contents)
  {
    string[] result = base.ValidModelExpected(name, parent, contents);
    return [$"!_Domain{DomainKind}", result[1], $"domainKind: !_DomainKind {DomainKind}", .. result[2..]];
  }

  protected override string[] WithItemExpected(string name, TInput item)
  {
    string[] result = base.WithItemExpected(name, item);
    return [$"!_Domain{DomainKind}", .. result[1..3], $"domainKind: !_DomainKind {DomainKind}", .. result[3..]];
  }

  protected abstract DomainKindModel DomainKind { get; }
}

public abstract class DomainItemRendererTestBase<TItem, TInput>
  : RendererClassTestBase<TItem>
  where TItem : BaseDomainItemModel
{
  [Theory, RepeatData]
  public void Render_WithItem_ReturnsStructured(TInput item, bool excluded)
    => RenderAndCheck(NewItem(item, excluded), ItemExpected(item, excluded));

  protected abstract string[] ItemExpected(TInput item, bool excluded);
  protected abstract TItem NewItem(TInput item, bool excluded);
}

public abstract class DomainAllRendererTestBase<TItem, TInput>
  : RendererClassTestBase<DomainItemModel<TItem>>
  where TItem : BaseDomainItemModel
{
  protected IRenderer<TItem> Item { get; }

  protected DomainAllRendererTestBase()
  {
    Item = RFor<TItem>();

    Renderer = new DomainItemRenderer<TItem>(Item);
  }

  protected override IRenderer<DomainItemModel<TItem>> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithItem_ReturnsStructured(string name, TInput item)
  {
    RenderReturnsMap(Item, "_ItemModel", item);
    RenderAndCheck(new(NewItem(item), name), AllExpected(name, item));
  }

  protected abstract string[] AllExpected(string name, TInput item);
  protected abstract TItem NewItem(TInput item);
}
