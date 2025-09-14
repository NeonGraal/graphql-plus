namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectFieldTestBase<TModel, TBase, TField, TAlt>
  : ResolverTypeObjectTypeTestBase<TModel, TBase, TField, TAlt>
  where TModel : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
{
  [Theory, RepeatData]
  public void ModelWithFieldModifier_ResolvesCorrectly(string name, FieldInput field, string key)
  {
    ModifierModel modifier = new(ModifierKind.Dict) { Key = key };
    TField objField = MakeModifierField(field, modifier);
    ObjectForModel allField = new ObjectForModel<TField>(objField, name);
    TModel model = NewModel(name, "") with {
      Fields = [objField],
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Fields.ShouldContain(objField),
        r => r.AllFields.ShouldContain(allField));
  }

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
  public void ModelWithParamParentFields_ResolvesCorrectly(string name, string parent, FieldInput[] fields)
  {
    TField[] objFields = [.. fields.Select(MakeField)];
    ObjectForModel[] allFields = [.. objFields.Select(f => new ObjectForModel<TField>(f, parent))];
    TModel parentModel = NewModel(parent, "") with {
      Fields = objFields,
    };
    Context.Types.Add("$" + parent, parentModel);

    TModel model = NewModel(name, "") with {
      Parent = NewParam(parent),
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.AllFields.ShouldBeEquivalentTo(allFields));
  }

  [Theory, RepeatData]
  public void ModelWithParentWithArgFieldModifier_ResolvesCorrectly(string name, string parent, FieldInput field, string key)
  {
    ModifierModel modifier = new(ModifierKind.Dict) { Key = key };
    TModel parentModel = NewModel(parent, "") with {
      TypeParams = [new(field.Type, "", default!)],
      Fields = [MakeParamField(field, modifier)],
    };
    Context.AddModels([parentModel]);

    TModel fieldModel = NewModel(field.Type, "");
    Context.Types["$" + field.Type] = fieldModel;

    TModel model = NewModel(name, "") with {
      Parent = MakeBase(parent, "", NewArg(field.Type)),
    };

    TField expectedField = MakeModifierField(field, modifier);
    ObjectForModel[] allFields = [new ObjectForModel<TField>(expectedField, parent)];
    TModel expectedModel = parentModel with {
      Fields = [expectedField],
      AllFields = allFields,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.ParentModel.ShouldBeEquivalentTo(expectedModel),
        r => r.AllFields.ShouldBeEquivalentTo(allFields));
  }

  [Theory, RepeatData]
  public void ModelWithParentWithFieldArgModifier_ResolvesCorrectly(string name, string parent, FieldInput field, string key)
  {
    ModifierModel modifier = new(ModifierKind.Param) { Key = key };
    TModel parentModel = NewModel(parent, "") with {
      TypeParams = [new(key, "", default!)],
      Fields = [MakeModifierField(field, modifier)],
    };
    Context.AddModels([parentModel]);

    TypeEnumModel enumModel = new(key, "");
    Context.Types["$" + key] = enumModel;

    TModel model = NewModel(name, "") with {
      Parent = MakeBase(parent, "", NewArg(key)),
    };

    TField expectedField = MakeModifierField(field, new(ModifierKind.Dict) { Key = key });
    ObjectForModel[] allFields = [new ObjectForModel<TField>(expectedField, parent)];
    TModel expectedModel = parentModel with {
      Fields = [expectedField],
      AllFields = allFields,
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.ParentModel.ShouldBeEquivalentTo(expectedModel),
        r => r.AllFields.ShouldBeEquivalentTo(allFields));
  }

  [Theory, RepeatData]
  public void ModelWithParentFields_ResolvesCorrectly(string name, string parent, FieldInput[] fields)
  {
    TField[] objFields = [.. fields.Select(MakeField)];
    ObjectForModel[] allFields = [.. objFields.Select(f => new ObjectForModel<TField>(f, parent))];
    TModel parentModel = NewModel(parent, "") with {
      Fields = objFields,
    };
    Context.AddModels([parentModel]);

    TModel model = NewModel(name, "") with {
      Parent = NewParent(parent, ""),
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.AllFields.ShouldBeEquivalentTo(allFields));
  }

  protected abstract TField MakeField(FieldInput field);
  protected abstract TField MakeModifierField(FieldInput field, ModifierModel modifier);
  protected abstract TField MakeParamField(FieldInput field, ModifierModel modifier);
}
