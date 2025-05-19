namespace GqlPlus.Resolving;

public class TypeInputResolverTests
  : ResolverClassTestBase<TypeInputModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeInputResolver(dual);
  }

  [Theory, RepeatData]
  public void NewItem_CreatesInputMemberModel_WithExpectedProperties(string name, string contents)
  {
    TypeInputModel model = new(name, contents);

    TypeInputModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents));
  }
}
