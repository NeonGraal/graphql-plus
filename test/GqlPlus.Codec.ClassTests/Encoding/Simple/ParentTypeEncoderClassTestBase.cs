namespace GqlPlus.Encoding.Simple;

public abstract class ParentTypeEncoderClassTestBase<TModel, TItem, TAll, TInput>
  : EncoderClassTestBase<TModel>
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  protected IEncoder<TypeRefModel<SimpleKindModel>> Parent { get; }
  protected IEncoder<TItem> Item { get; }
  protected IEncoder<TAll> All { get; }

  internal ParentTypeEncoders<TItem, TAll> Encoders { get; }

  protected abstract SimpleKindModel Kind { get; }

  protected ParentTypeEncoderClassTestBase()
  {
    Parent = RFor<TypeRefModel<SimpleKindModel>>();
    Item = RFor<TItem>();
    All = RFor<TAll>();

    Encoders = new(Parent, Item, All);
  }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string parent, string contents)
  {
    TypeRefModel<SimpleKindModel> parentModel = new(Kind, parent, "");
    EncodeReturns(Parent, parentModel, new Structured(parent, "_TypeRef(_SimpleKind)"));
    EncodeAndCheck(NewModel(name, contents, parentModel), ValidModelExpected(name, parent, contents));
  }

  protected virtual string[] ValidModelExpected(string name, string parent, string contents)
    => [$"!_Type{Kind}",
        "description: " + contents.QuotedIdentifier(),
        "name: " + name,
        "parent: !_TypeRef(_SimpleKind) " + parent,
        $"typeKind: !_TypeKind {Kind}"
        ];

  [Theory, RepeatData]
  public void Encode_WithItem_ReturnsStructured(string name, TInput item)
  {
    EncodeReturns(Item, Arg.Any<TItem>(), new($"{item}", "_ItemModel"));
    EncodeReturns(All, Arg.Any<TAll>(), new($"{item}", "_AllModel"));

    EncodeAndCheck(NewModel(name, "", null) with {
      Items = [NewItem(item)],
      AllItems = [NewAll(item, name)]
    }, WithItemExpected(name, item));
  }

  protected virtual string[] WithItemExpected(string name, TInput item)
    => [$"!_Type{Kind}",
        "allItems:",
        $"  - !_AllModel " + item.QuotedIdentifier(),
        "items:",
        $"  - !_ItemModel " + item.QuotedIdentifier(),
        "name: " + name,
        $"typeKind: !_TypeKind {Kind}"
        ];

  protected abstract TAll NewAll(TInput item, string name);
  protected abstract TItem NewItem(TInput item);
  protected abstract TModel NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent);
}
