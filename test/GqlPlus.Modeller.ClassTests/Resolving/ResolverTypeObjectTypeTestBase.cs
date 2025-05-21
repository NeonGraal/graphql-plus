namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectTypeTestBase<TModel, TBase, TField, TAlt>
  : ResolverChildTypeTestBase<TModel, TBase>
  where TModel : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
{
  [Theory, RepeatData]
  public void ModelWithFields_ResolvesCorrectly(string name, FieldInput[] fields)
  {
    TField[] objFields = [.. fields.Select(MakeField)];
    ObjectForModel[] allFields = [.. objFields.Select(f => new ObjectForModel<TField>(f, name))];
    TModel model = NewModel(name, "") with {
      Fields = objFields,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Fields.ShouldBeEquivalentTo(objFields),
        r => r.AllFields.ShouldBeEquivalentTo(allFields));
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
  public void ModelWithParentFields_ResolvesCorrectly(string name, string parent, FieldInput[] fields)
  {
    TField[] objFields = [.. fields.Select(MakeField)];
    ObjectForModel[] allFields = [.. objFields.Select(f => new ObjectForModel<TField>(f, parent))];
    TModel parentModel = NewModel(parent, "") with {
      Fields = objFields,
    };
    Context.TryGetType(name, parent, out TModel? parentType).Returns(c => { c[2] = parentModel; return true; });

    TModel model = NewModel(name, "") with {
      Parent = NewParent(parent, ""),
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.AllFields.ShouldBeEquivalentTo(allFields));
  }

  [Theory, RepeatData]
  public void ModelWithParentAlternates_ResolvesCorrectly(string name, string parent, string[] alternates)
  {
    TAlt[] objAlternates = [.. alternates.Select(MakeAlternate)];
    ObjectForModel[] allAlternates = [.. objAlternates.Select(a => new ObjectForModel<TAlt>(a, parent))];
    TModel parentModel = NewModel(parent, "") with {
      Alternates = objAlternates,
    };
    Context.TryGetType(name, parent, out TModel? parentType).Returns(c => { c[2] = parentModel; return true; });

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
  protected abstract TField MakeField(FieldInput field);
}
