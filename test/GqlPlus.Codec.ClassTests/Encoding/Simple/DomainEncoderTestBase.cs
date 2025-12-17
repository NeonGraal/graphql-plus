namespace GqlPlus.Encoding.Simple;

public abstract class DomainEncoderTestBase<TItem, TInput>
  : ParentTypeEncoderClassTestBase<BaseDomainModel<TItem>, TItem, DomainItemModel<TItem>, TInput>
  where TItem : BaseDomainItemModel
{
  protected DomainEncoderTestBase()
    => Encoder = new BaseDomainEncoder<TItem>(Encoders);

  protected override IEncoder<BaseDomainModel<TItem>> Encoder { get; }
  protected override SimpleKindModel Kind => SimpleKindModel.Domain;

  protected override BaseDomainModel<TItem> NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent)
    => new(DomainKind, name, contents) { Parent = parent };
  protected override DomainItemModel<TItem> NewAll(TInput item, string name) => new(NewItem(item), name);
  protected override string[] ValidModelExpected(string name, string parent, string contents)
  {
    string[] result = [.. base.ValidModelExpected(name, parent, contents)
      .Select(s => s.Replace($"_Type{Kind}", $"_Domain{DomainKind}", StringComparison.InvariantCulture))];
    return [result[0], $"[_Domain{DomainKind}]:domainKind=[_DomainKind]{DomainKind}", .. result[1..]];
  }

  protected override string[] WithItemExpected(string name, TInput item)
  {
    string[] result = [..base.WithItemExpected(name, item)
      .Select(s => s.Replace($"_Type{Kind}", $"_Domain{DomainKind}", StringComparison.InvariantCulture))];
    return [result[0], $"[_Domain{DomainKind}]:domainKind=[_DomainKind]{DomainKind}", .. result[1..]];
  }

  protected abstract DomainKindModel DomainKind { get; }
}

public abstract class DomainItemEncoderTestBase<TItem, TInput>
  : EncoderClassTestBase<TItem>
  where TItem : BaseDomainItemModel
{
  [Theory, RepeatData]
  public void Encode_WithItem_ReturnsStructured(TInput item, bool excluded, string contents)
    => EncodeAndCheck(NewItem(item, excluded, contents), ItemExpected(item, excluded, contents));

  protected abstract string[] ItemExpected(TInput item, bool excluded, string description);
  protected abstract TItem NewItem(TInput item, bool excluded, string description);
}

public abstract class DomainAllEncoderTestBase<TItem, TInput>
  : EncoderClassTestBase<DomainItemModel<TItem>>
  where TItem : BaseDomainItemModel
{
  protected IEncoder<TItem> Item { get; }

  protected DomainAllEncoderTestBase()
  {
    Item = RFor<TItem>();

    Encoder = new DomainItemEncoder<TItem>(Item);
  }

  protected override IEncoder<DomainItemModel<TItem>> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithItem_ReturnsStructured(string name, TInput item, string contents)
  {
    EncodeReturnsMap(Item, "_ItemModel", item);
    EncodeAndCheck(new(NewItem(item, contents), name), AllExpected(name, item, contents));
  }

  protected abstract string[] AllExpected(string name, TInput item, string description);
  protected abstract TItem NewItem(TInput item, string description);
}
