namespace GqlPlus.Resolving;

public abstract class ResolverParentTypeTestBase<TModel, TAll>
  : ResolverParentTypeTestBase<TModel, AliasedModel, TAll>
  where TModel : ParentTypeModel<AliasedModel, TAll>
  where TAll : IModelBase
{
  protected override AliasedModel NewItem(string name) => new(name, "");
}

public abstract class ResolverParentTypeTestBase<TModel, TItem, TAll>
  : ResolverChildTypeTestBase<TModel>
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  [Theory, RepeatData]
  public void CreatesModel_WithItems(string name, string[] items)
  {
    TItem[] itemModels = [.. items.Select(NewItem)];
    TAll[] allModels = [.. itemModels.Select(AllItem(name))];
    TModel model = NewModel(name, "") with {
      Items = itemModels,
      AllItems = allModels,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Items.ShouldBeEquivalentTo(itemModels),
        r => r.AllItems.ShouldBeEquivalentTo(allModels));
  }

  [Theory, RepeatData]
  public void CreatesModel_WithParentItems(string name, string parent, string[] items)
  {
    TItem[] itemModels = [.. items.Select(NewItem)];
    TAll[] allModels = [.. itemModels.Select(AllItem(parent))];
    TModel parentModel = NewModel(parent, "") with {
      Items = itemModels,
      AllItems = allModels,
    };
    Context.TryGetType(name, parentModel.Name, out TModel? parentType).Returns(c => { c[2] = parentModel; return true; });

    TModel model = NewModel(name, "") with {
      Parent = NewParent(parent, "")
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.ParentModel.ShouldBe(parentModel),
        r => r.AllItems.ShouldBeEquivalentTo(allModels));
  }

  protected abstract TItem NewItem(string name);
  protected abstract Func<TItem, TAll> AllItem(string name);
}
