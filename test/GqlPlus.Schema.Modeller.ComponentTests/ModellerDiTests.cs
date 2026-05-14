using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class ModellerDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "Modeller";
}
