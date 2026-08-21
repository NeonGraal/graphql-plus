namespace GqlPlus;

public class ModellerDiTests(ComponentFixture<Startup> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<Startup>>
{
  protected override string Label => "Modeller";
}
