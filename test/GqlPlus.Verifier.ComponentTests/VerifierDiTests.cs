using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class VerifierDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "Verifier";
}
