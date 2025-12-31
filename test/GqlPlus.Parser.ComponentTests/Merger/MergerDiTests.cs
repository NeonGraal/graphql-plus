using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Merger;

public class MergerDiTests(IServiceCollection services)
  : DependencyInjectionChecks(services)
{
  protected override string Label => "Merger";
}
