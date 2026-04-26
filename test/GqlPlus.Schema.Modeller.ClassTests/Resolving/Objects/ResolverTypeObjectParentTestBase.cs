namespace GqlPlus.Resolving.Objects;

public abstract class ResolverTypeObjectParentTestBase<TModel, TField>
  : ResolverTypeObjectTypeTestBase<TModel, TField>
  where TModel : TypeObjectModel<TField>
  where TField : IObjFieldModel
{
  [Theory, RepeatData]
  public void ModelWithParentWithArgParent_ResolvesCorrectly(string name, string parent, string grandParent)
  {
    this.SkipEqual(parent, grandParent);

    TModel parentModel = NewModel(parent, "") with {
      TypeParams = [new(grandParent, "", default!)],
      Parent = NewParam(grandParent),
    };
    TModel grandModel = NewModel(grandParent, "");
    Context.AddModels([parentModel, grandModel]);

    ObjBaseModel expectedBase = MakeBase(parent, "", NewArg(grandParent));
    TModel expectedModel = parentModel with {
      Parent = MakeBase(grandParent, ""),
      ParentModel = grandModel,
    };

    TModel model = NewModel(name, "") with {
      Parent = MakeBase(parent, "", NewArg(grandParent)),
    };

    TModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Parent.ShouldBeEquivalentTo(expectedBase),
        r => r.ParentModel.ShouldBeEquivalentTo(expectedModel)
        );
  }
}
