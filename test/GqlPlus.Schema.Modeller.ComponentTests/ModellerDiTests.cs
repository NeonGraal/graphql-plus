using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class ModellerDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "Modeller";
}
