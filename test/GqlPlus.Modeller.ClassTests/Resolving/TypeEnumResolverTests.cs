namespace GqlPlus.Resolving;

public class TypeEnumResolverTests
  : ResolverClassTestBase<TypeEnumModel>
{
  protected override IResolver<TypeEnumModel> Resolver { get; }
    = new TypeEnumResolver();

  [Theory, RepeatData]
  public void NewItem_CreatesEnumLabelModel_WithExpectedProperties(string name, string contents)
  {
    TypeEnumModel model = new(name, contents);

    TypeEnumModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents));
  }
}
