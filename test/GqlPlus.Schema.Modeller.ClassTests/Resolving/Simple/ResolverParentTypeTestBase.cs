
namespace GqlPlus.Resolving.Simple;

public abstract class ResolverParentTypeTestBase<TModel, TAll>
  : ResolverParentTypeTestBase<TModel, string, AliasedModel, TAll>
  where TModel : ParentTypeModel<AliasedModel, TAll>
  where TAll : IModelBase
{
  protected override AliasedModel NewItem(string name) => new(name, "");
}

public abstract class ResolverParentTypeTestBase<TModel, TInput, TItem, TAll>
  : ResolverChildTypeTestBase<TModel, TypeRefModel<SimpleKindModel>>
  where TModel : ParentTypeModel<TItem, TAll>
  where TItem : IModelBase
  where TAll : IModelBase
{
  [Theory, RepeatData]
  public void CreatesModel_WithItems(string name, TInput[] items)
  {
    this.SkipIf(DuplicateItems(items));

    TItem[] itemModels = [.. items.Select(NewItem)];
    TAll[] allModels = [.. itemModels.Select(AllItem(name))];
    TModel model = NewModel(name, "") with {
      Items = itemModels,
      AllItems = allModels,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldSatisfyAllConditions(
      r => r.ShouldNotBeNull(),
        r => r.Name.ShouldBe(name),
        r => r.Items.ShouldBeEquivalentTo(itemModels),
        r => r.AllItems.ShouldBeEquivalentTo(allModels));
  }

  [Theory, RepeatData]
  public void CreatesModel_WithParentItems(string name, string parent, TInput[] items)
  {
    this.SkipIf(DuplicateItems(items));

    TItem[] itemModels = [.. items.Select(NewItem)];
    TAll[] allModels = [.. itemModels.Select(AllItem(parent))];
    TModel parentModel = NewModel(parent, "") with {
      Items = itemModels,
      AllItems = allModels,
    };
    Context.AddModels([parentModel]);

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

  protected virtual bool DuplicateItems(TInput[] items)
    => items.ThrowIfNull().Length != items.Distinct().Count();
  protected abstract TItem NewItem(TInput name);
  protected abstract Func<TItem, TAll> AllItem(string name);
}
