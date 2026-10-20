namespace GqlPlus.Resolving;

public class ResolverDiTests(ComponentFixture<ResolverTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<ResolverTestServices>>
{
  protected override string Label => "Resolver";
}
