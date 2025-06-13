namespace GqlPlus.Rendering.Simple;

public abstract class BaseDomainRendererTests<TItem, TInput>
  : ParentTypeRendererClassTestBase<BaseDomainModel<TItem>, TItem, DomainItemModel<TItem>, TInput>
  where TItem : BaseDomainItemModel
{
  protected BaseDomainRendererTests()
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
