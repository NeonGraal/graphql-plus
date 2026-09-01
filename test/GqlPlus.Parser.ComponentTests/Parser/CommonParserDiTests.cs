namespace GqlPlus.Parser;

public class CommonParserDiTests(ComponentFixture<ParserTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<ParserTestServices>>
{
  protected override string Label => "CommonParser";
}
