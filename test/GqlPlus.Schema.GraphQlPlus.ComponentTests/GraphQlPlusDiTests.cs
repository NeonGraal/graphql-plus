namespace GqlPlus;

public class GraphQlPlusDiTests(ComponentFixture<SchemaGraphQlTestServices> fixture)
  : DiChecks(fixture.ServiceCollection)
  , IClassFixture<ComponentFixture<SchemaGraphQlTestServices>>
{
  protected override string Label => "GraphQlPlus";
}
