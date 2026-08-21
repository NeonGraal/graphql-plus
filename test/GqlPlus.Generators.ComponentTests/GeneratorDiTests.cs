namespace GqlPlus;

public class GeneratorDiTests(ComponentFixture<GeneratorTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<GeneratorTestServices>>
{
  protected override string Label => "Generator";
}
