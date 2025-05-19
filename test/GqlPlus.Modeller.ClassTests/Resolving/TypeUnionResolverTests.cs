namespace GqlPlus.Resolving;

public class TypeUnionResolverTests
  : ResolverClassTestBase<TypeUnionModel>
{
  protected override IResolver<TypeUnionModel> Resolver { get; }
    = new TypeUnionResolver();

  [Theory, RepeatData]
  public void NewItem_CreatesUnionMemberModel_WithExpectedProperties(string name, string contents)
  {
    TypeUnionModel model = new(name, contents);

    TypeUnionModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents));
  }
}
