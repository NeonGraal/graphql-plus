namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectAlternateTestBase<TModel, TBase, TField, TAlt, TArg>
  : ResolverTypeObjectTypeTestBase<TModel, TBase, TField, TAlt, TArg>
  where TModel : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
  where TArg : IObjTypeArgModel
{
  [Theory, RepeatData]
  public void ModelWithAlternateCollection_ResolvesCorrectly(string name, string alternate, string key)
  {
    ModifierModel modifier = new(ModifierKind.Dict) { Key = key };
    TAlt objAlternate = MakeCollectionAlternate(alternate, modifier);
    ObjectForModel allAlternate = new ObjectForModel<TAlt>(objAlternate, name);
    TModel model = NewModel(name, "") with {
      Alternates = [objAlternate],
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Alternates.ShouldContain(objAlternate),
        r => r.AllAlternates.ShouldContain(allAlternate));
  }

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
  public void ModelWithParentWithAlternateArgCollection_ResolvesCorrectly(string name, string parent, string alternate, string key)
  {
    TModel parentModel = NewModel(parent, "") with {
      TypeParams = [new(key, "")],
      Alternates = [MakeCollectionAlternate(alternate, new(ModifierKind.Param) { Key = key })],
    };
    Context.AddModels([parentModel]);

    TypeEnumModel enumModel = new(key, "");
    Context.Types["$" + key] = enumModel;

    TModel model = NewModel(name, "") with {
      Parent = MakeBase(parent, "", NewArg(key)),
    };

    TAlt expectedAlternate = MakeCollectionAlternate(alternate, new(ModifierKind.Dict) { Key = key });
    ObjectForModel[] allAlternates = [new ObjectForModel<TAlt>(expectedAlternate, parent)];
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
      TypeParams = [new(alternate, "")],
      Alternates = [MakeParamAlternate(alternate, collection)],
    };
    Context.AddModels([parentModel]);

    TModel alternateModel = NewModel(alternate, "");
    Context.Types["$" + alternate] = alternateModel;

    TModel model = NewModel(name, "") with {
      Parent = MakeBase(parent, "", NewArg(alternate)),
    };

    TAlt expectedAlternate = MakeCollectionAlternate(alternate, collection);
    ObjectForModel[] allAlternates = [new ObjectForModel<TAlt>(expectedAlternate, parent)];
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
  protected abstract TAlt MakeCollectionAlternate(string alternate, CollectionModel collection);
  protected abstract TAlt MakeParamAlternate(string alternate, CollectionModel collection);
}
