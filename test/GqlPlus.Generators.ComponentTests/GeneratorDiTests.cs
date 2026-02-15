using Microsoft.Extensions.DependencyInjection;

using Xunit.DependencyInjection;

namespace GqlPlus;

public class GeneratorDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "Generator";
}
