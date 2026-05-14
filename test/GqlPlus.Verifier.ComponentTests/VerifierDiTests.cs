using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class VerifierDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "Verifier";
}
