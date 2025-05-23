namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectAlternateTestBase<TModel, TBase, TField, TAlt, TArg>
  : ResolverTypeObjectTypeTestBase<TModel, TBase, TField, TAlt, TArg>
  where TModel : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
  where TArg : IObjArgModel
{
  [Theory, RepeatData]
  public void ModelWithAlternates_ResolvesCorrectly(string name, string[] alternates)
  {
    TAlt[] objAlternates = [.. alternates.Select(MakeAlternate)];
    ObjectForModel[] allAlternates = [.. objAlternates.Select(a => new ObjectForModel<TAlt>(a, name))];
    TModel model = NewModel(name, "") with {
      Alternates = objAlternates,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Alternates.ShouldBeEquivalentTo(objAlternates),
        r => r.AllAlternates.ShouldBeEquivalentTo(allAlternates));
  }

  [Theory, RepeatData]
  public void ModelWithParamParentAlternates_ResolvesCorrectly(string name, string parent, string[] alternates)
  {
    TAlt[] objAlternates = [.. alternates.Select(MakeAlternate)];
    ObjectForModel[] allAlternates = [.. objAlternates.Select(a => new ObjectForModel<TAlt>(a, parent))];
    TModel parentModel = NewModel(parent, "") with {
      Alternates = objAlternates,
    };
    Context.Types["$" + parent] = parentModel;

    TModel model = NewModel(name, "") with {
      Parent = NewParam(parent),
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.AllAlternates.ShouldBeEquivalentTo(allAlternates));
  }

  [Theory, RepeatData]
  public void ModelWithParentAlternates_ResolvesCorrectly(string name, string parent, string[] alternates)
  {
    TAlt[] objAlternates = [.. alternates.Select(MakeAlternate)];
    ObjectForModel[] allAlternates = [.. objAlternates.Select(a => new ObjectForModel<TAlt>(a, parent))];
    TModel parentModel = NewModel(parent, "") with {
      Alternates = objAlternates,
    };
    Context.AddModels([parentModel]);

    TModel model = NewModel(name, "") with {
      Parent = NewParent(parent, ""),
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.AllAlternates.ShouldBeEquivalentTo(allAlternates));
  }

  protected abstract TAlt MakeAlternate(string alternate);
  protected abstract TAlt MakeParamAlternate(string alternate);
}
