using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class GeneratorDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "Generator";
}
