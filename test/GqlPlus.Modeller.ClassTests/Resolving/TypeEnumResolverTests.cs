namespace GqlPlus.Resolving;

public class TypeEnumResolverTests
{
  private readonly TypeEnumResolver _resolver;

  public TypeEnumResolverTests()
    => _resolver = new TypeEnumResolver();

  [Theory, RepeatData]
  public void NewItem_CreatesEnumLabelModel_WithExpectedProperties(string name, string contents)
  {
    TypeEnumModel model = new(name, contents);

    IResolveContext context = Substitute.For<IResolveContext>();

    TypeEnumModel result = _resolver.Resolve(model, context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents));
  }
}
