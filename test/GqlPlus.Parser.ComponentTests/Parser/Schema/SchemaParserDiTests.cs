namespace GqlPlus.Parser.Schema;

public class SchemaParserDiTests(ComponentFixture<Startup> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<Startup>>
{
  protected override string Label => "SchemaParser";
}
