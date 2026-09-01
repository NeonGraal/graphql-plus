namespace GqlPlus;

public class ModellerDiTests(ComponentFixture<ModellerTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<ModellerTestServices>>
{
  protected override string Label => "Modeller";
}
