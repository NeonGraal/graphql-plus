namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectParentTestBase<TModel, TBase, TField, TAlt, TArg>
  : ResolverTypeObjectTypeTestBase<TModel, TBase, TField, TAlt, TArg>
  where TModel : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
  where TArg : IObjTypeArgModel
{
  [Theory, RepeatData]
  public void ModelWithParentWithArgParent_ResolvesCorrectly(string name, string parent, string grandParent)
  {
    this.SkipIf(parent == grandParent);

    TModel parentModel = NewModel(parent, "") with {
      TypeParams = [new(grandParent, "", default!)],
      Parent = NewParam(grandParent),
    };
    TModel grandModel = NewModel(grandParent, "");
    Context.AddModels([parentModel, grandModel]);

    TBase expectedBase = MakeBase(parent, "", NewArg(grandParent));
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
