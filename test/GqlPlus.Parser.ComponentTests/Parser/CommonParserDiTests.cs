namespace GqlPlus.Parser;

public class CommonParserDiTests(ComponentFixture<Startup> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<Startup>>
{
  protected override string Label => "CommonParser";
}
