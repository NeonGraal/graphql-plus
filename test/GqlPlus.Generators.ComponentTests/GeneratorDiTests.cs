using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class GeneratorDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "Generator";
}
