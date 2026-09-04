namespace GqlPlus.Parser.Schema;

public class SchemaParserDiTests(ComponentFixture<SchemaParserTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<SchemaParserTestServices>>
{
  protected override string Label => "SchemaParser";
}
