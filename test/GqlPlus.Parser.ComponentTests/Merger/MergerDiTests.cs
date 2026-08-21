namespace GqlPlus.Merger;

public class MergerDiTests(ComponentFixture<Startup> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<Startup>>
{
  protected override string Label => "Merger";
}
