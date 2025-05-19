namespace GqlPlus.Resolving;

public class TypeUnionResolverTests
{
  private readonly TypeUnionResolver _resolver;

  public TypeUnionResolverTests()
    => _resolver = new TypeUnionResolver();

  [Theory, RepeatData]
  public void NewItem_CreatesUnionMemberModel_WithExpectedProperties(string name, string contents)
  {
    TypeUnionModel model = new(name, contents);

    IResolveContext context = Substitute.For<IResolveContext>();

    TypeUnionModel result = _resolver.Resolve(model, context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents));
  }
}
