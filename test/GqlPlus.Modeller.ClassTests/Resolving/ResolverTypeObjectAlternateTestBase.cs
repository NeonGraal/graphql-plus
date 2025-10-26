namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectAlternateTestBase<TModel, TField>
  : ResolverTypeObjectTypeTestBase<TModel, TField>
  where TModel : TypeObjectModel<TField>
  where TField : IObjFieldModel
{
  [Theory, RepeatData]
  public void ModelWithAlternateCollection_ResolvesCorrectly(string name, string alternate, string key)
  {
    ModifierModel modifier = new(ModifierKind.Dict) { Key = key };
    AlternateModel theAlternate = MakeCollectionAlternate(alternate, modifier);
    ObjectForModel allAlternate = new ObjectForModel<AlternateModel>(theAlternate, name);
    TModel model = NewModel(name, "") with {
      Alternates = [theAlternate],
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Alternates.ShouldContain(theAlternate),
        r => r.AllAlternates.ShouldContain(allAlternate));
  }

  [Theory, RepeatData]
  public void ModelWithAlternates_ResolvesCorrectly(string name, string[] alternates)
  {
    AlternateModel[] theAlternates = [.. alternates.Select(MakeAlternate)];
    ObjectForModel[] allAlternates = [.. theAlternates.Select(a => new ObjectForModel<AlternateModel>(a, name))];
    TModel model = NewModel(name, "") with {
      Alternates = theAlternates,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Alternates.ShouldBeEquivalentTo(theAlternates),
        r => r.AllAlternates.ShouldBeEquivalentTo(allAlternates));
  }

  [Theory, RepeatData]
  public void ModelWithParamParentAlternates_ResolvesCorrectly(string name, string parent, string[] alternates)
  {
    AlternateModel[] theAlternates = [.. alternates.Select(MakeAlternate)];
    ObjectForModel[] allAlternates = [.. theAlternates.Select(a => new ObjectForModel<AlternateModel>(a, parent))];
    TModel parentModel = NewModel(parent, "") with {
      Alternates = theAlternates,
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
  public void ModelWithParentWithAlternateArgCollection_ResolvesCorrectly(string name, string parent, string alternate, string key)
  {
    TModel parentModel = NewModel(parent, "") with {
      TypeParams = [new(key, "", default!)],
      Alternates = [MakeCollectionAlternate(alternate, new(ModifierKind.Param) { Key = key })],
    };
    Context.AddModels([parentModel]);

    TypeEnumModel enumModel = new(key, "");
    Context.Types["$" + key] = enumModel;

    TModel model = NewModel(name, "") with {
      Parent = MakeBase(parent, "", NewArg(key)),
    };

    AlternateModel expectedAlternate = MakeCollectionAlternate(alternate, new(ModifierKind.Dict) { Key = key });
    ObjectForModel[] allAlternates = [new ObjectForModel<AlternateModel>(expectedAlternate, parent)];
    TModel expectedParent = parentModel with {
      Alternates = [expectedAlternate],
      AllAlternates = allAlternates,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.ParentModel.ShouldBeEquivalentTo(expectedParent),
        r => r.AllAlternates.ShouldBeEquivalentTo(allAlternates));
  }

  [Theory, RepeatData]
  public void ModelWithParentWithArgAlternateCollection_ResolvesCorrectly(string name, string parent, string alternate, string key)
  {
    CollectionModel collection = new(ModifierKind.Dict) { Key = key };
    TModel parentModel = NewModel(parent, "") with {
      TypeParams = [new(alternate, "", default!)],
      Alternates = [MakeParamAlternate(alternate, collection)],
    };
    Context.AddModels([parentModel]);

    TModel alternateModel = NewModel(alternate, "");
    Context.Types["$" + alternate] = alternateModel;

    TModel model = NewModel(name, "") with {
      Parent = MakeBase(parent, "", NewArg(alternate)),
    };

    AlternateModel expectedAlternate = MakeCollectionAlternate(alternate, collection);
    ObjectForModel[] allAlternates = [new ObjectForModel<AlternateModel>(expectedAlternate, parent)];
    TModel expectedParent = parentModel with {
      Alternates = [expectedAlternate],
      AllAlternates = allAlternates,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.ParentModel.ShouldBeEquivalentTo(expectedParent),
        r => r.AllAlternates.ShouldBeEquivalentTo(allAlternates));
  }

  [Theory, RepeatData]
  public void ModelWithParentAlternates_ResolvesCorrectly(string name, string parent, string[] alternates)
  {
    AlternateModel[] theAlternates = [.. alternates.Select(MakeAlternate)];
    ObjectForModel[] allAlternates = [.. theAlternates.Select(a => new ObjectForModel<AlternateModel>(a, parent))];
    TModel parentModel = NewModel(parent, "") with {
      Alternates = theAlternates,
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

  protected abstract AlternateModel MakeAlternate(string alternate);
  protected abstract AlternateModel MakeCollectionAlternate(string alternate, CollectionModel collection);
  protected abstract AlternateModel MakeParamAlternate(string alternate, CollectionModel collection);
}
