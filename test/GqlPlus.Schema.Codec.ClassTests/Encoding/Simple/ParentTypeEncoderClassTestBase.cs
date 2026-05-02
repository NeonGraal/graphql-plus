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

  internal IEncoderRepository Encoders { get; }

  protected abstract SimpleKindModel Kind { get; }

  protected ParentTypeEncoderClassTestBase()
  {
    Parent = RFor<TypeRefModel<SimpleKindModel>>();
    Item = RFor<TItem>();
    All = RFor<TAll>();

    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderForReturns(Parent);
    encoders.EncoderForReturns(Item);
    encoders.EncoderForReturns(All);
    Encoders = encoders;
  }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string parent, string contents)
  {
    TypeRefModel<SimpleKindModel> parentModel = new(Kind, parent, "");
    EncodeReturns(Parent, parentModel, parent.Encode("_TypeRef(_SimpleKind)"));
    EncodeAndCheck(NewModel(name, contents, parentModel), ValidModelExpected(name, parent, contents));
  }

  protected virtual string[] ValidModelExpected(string name, string parent, string contents)
    => TagAll($"_Type{Kind}",
        ":description=" + contents.QuotedIdentifier(),
        ":name=" + name,
        ":parent=[_TypeRef(_SimpleKind)]" + parent,
        $":typeKind=[_TypeKind]{Kind}");

  [Theory, RepeatData]
  public void Encode_WithItem_ReturnsStructured(string name, TInput item)
  {
    EncodeReturns(Item, Arg.Any<TItem>(), $"{item}".Encode("_ItemModel"));
    EncodeReturns(All, Arg.Any<TAll>(), $"{item}".Encode("_AllModel"));

    EncodeAndCheck(NewModel(name, "", null) with {
      Items = [NewItem(item)],
      AllItems = [NewAll(item, name)]
    }, WithItemExpected(name, item));
  }

  protected virtual string[] WithItemExpected(string name, TInput item)
    => TagAll($"_Type{Kind}",
        ItemModel(item, ":allItems.0=[_All"),
        ItemModel(item, ":items.0=[_Item"),
        ":name=" + name,
        $":typeKind=[_TypeKind]{Kind}");

  protected virtual string ItemModel(TInput item, string prefix)
    => $"{prefix}Model]{item}";

  protected abstract TAll NewAll(TInput item, string name);
  protected abstract TItem NewItem(TInput item);
  protected abstract TModel NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent);
}
