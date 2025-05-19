namespace GqlPlus.Resolving;

public class TypeDualResolverTests
  : ResolverClassTestBase<TypeDualModel>
{
  protected override IResolver<TypeDualModel> Resolver { get; } = new TypeDualResolver();

  [Theory, RepeatData]
  public void NewItem_CreatesDualMemberModel_WithExpectedProperties(string name, string contents)
  {
    TypeDualModel model = new(name, contents);

    TypeDualModel result = Resolver.Resolve(model, Context);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        r => r.Name.ShouldBe(name),
        r => r.Description.ShouldBe(contents));
  }
}
