namespace GqlPlus.Merger;

public class MergerDiTests(ComponentFixture<MergerTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<MergerTestServices>>
{
  protected override string Label => "Merger";
}
