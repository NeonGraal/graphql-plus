namespace GqlPlus;

public class VerifierDiTests(ComponentFixture<VerifierTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<VerifierTestServices>>
{
  protected override string Label => "Verifier";
}
