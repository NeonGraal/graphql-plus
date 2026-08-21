namespace GqlPlus.Parser.Operation;

public class OperationParserDiTests(ComponentFixture<Startup> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<Startup>>
{
  protected override string Label => "OperationParser";
}
