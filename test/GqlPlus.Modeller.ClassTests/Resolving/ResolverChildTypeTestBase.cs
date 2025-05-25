namespace GqlPlus.Resolving;

public abstract class ResolverChildTypeTestBase<TModel, TParent>
  : ResolverClassTestBase<TModel>
  where TModel : ChildTypeModel<TParent>
  where TParent : IModelBase
{
  [Theory, RepeatData]
  public void MinimumModel_ResolvesCorrectly(string name, string contents)
  {
    TModel model = NewModel(name, contents);

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents));
  }

  [Theory, RepeatData]
  public void ModelWithParent_ResolvesCorrectly(string name, string parent, string contents)
  {
    TModel parentModel = NewModel(parent, contents);
    Context.AddModels([parentModel]);

    TModel model = NewModel(name, "") with {
      Parent = NewParent(parent, contents)
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
        .ShouldSatisfyAllConditions(
          r => r.Name.ShouldBe(name),
          r => r.ParentModel.ShouldBe(parentModel));
  }

  protected abstract TParent NewParent(string parent, string description);
  protected abstract TModel NewModel(string name, string description);
}
