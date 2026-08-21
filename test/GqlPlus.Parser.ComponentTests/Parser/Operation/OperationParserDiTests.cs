namespace GqlPlus.Parser.Operation;

public class OperationParserDiTests(ComponentFixture<OperationParserTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<OperationParserTestServices>>
{
  protected override string Label => "OperationParser";
}
