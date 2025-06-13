namespace GqlPlus.Rendering.Simple;

public abstract class ParentTypeRendererClassTestBase<TModel, TItem, TAll, TInput>
  : RendererClassTestBase<TModel>
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  protected IRenderer<TypeRefModel<SimpleKindModel>> Parent { get; }
  protected IRenderer<TItem> Item { get; }
  protected IRenderer<TAll> All { get; }

  internal ParentTypeRenderers<TItem, TAll> Renderers { get; }


  protected abstract SimpleKindModel Kind { get; }

  protected ParentTypeRendererClassTestBase()
  {
    Parent = RFor<TypeRefModel<SimpleKindModel>>();
    Item = RFor<TItem>();
    All = RFor<TAll>();

    Renderers = new(Parent, Item, All);
  }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string parent, string contents)
  {
    TypeRefModel<SimpleKindModel> parentModel = new(Kind, parent, "");
    RenderReturns(Parent, parentModel, new Structured(parent, "_TypeRef(_SimpleKind)"));
    RenderAndCheck(NewModel(name, contents, parentModel), ValidModelExpected(name, parent, contents));
  }

  protected virtual string[] ValidModelExpected(string name, string parent, string contents)
    => [$"!_Type{Kind}",
        "description: " + contents.Quoted("'"),
        "name: " + name,
        "parent: !_TypeRef(_SimpleKind) " + parent,
        $"typeKind: !_TypeKind {Kind}"
        ];

  [Theory, RepeatData]
  public void Render_WithItem_ReturnsStructured(string name, TInput item)
  {
    RenderReturns(Item, Arg.Any<TItem>(), StructureValue.Str($"{item}", "_ItemModel"));
    RenderReturns(All, Arg.Any<TAll>(), StructureValue.Str($"{item}", "_AllModel"));

    RenderAndCheck(NewModel(name, "", null) with {
      Items = [NewItem(item)],
      AllItems = [NewAll(item, name)]
    }, WithItemExpected(name, item));
  }

  protected virtual string[] WithItemExpected(string name, TInput item)
    => [$"!_Type{Kind}",
        "allItems:",
        $"  - !_AllModel '{item}'",
        "items:",
        $"  - !_ItemModel '{item}'",
        "name: " + name,
        $"typeKind: !_TypeKind {Kind}"
        ];

  protected abstract TAll NewAll(TInput item, string name);
  protected abstract TItem NewItem(TInput item);
  protected abstract TModel NewModel(string name, string contents, TypeRefModel<SimpleKindModel>? parent);
}
