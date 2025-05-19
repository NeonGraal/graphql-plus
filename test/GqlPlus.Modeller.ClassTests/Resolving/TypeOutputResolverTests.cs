namespace GqlPlus.Resolving;

public class TypeOutputResolverTests
  : ResolverClassTestBase<TypeOutputModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeOutputResolver(dual);
  }

  [Theory, RepeatData]
  public void NewItem_CreatesOutputMemberModel_WithExpectedProperties(string name, string contents)
  {
    TypeOutputModel model = new(name, contents);

    TypeOutputModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents));
  }
}
