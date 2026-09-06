namespace GqlPlus;

public class RequestDiTests(ComponentFixture<RequestTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<RequestTestServices>>
{
  protected override string Label => "Request";
}
