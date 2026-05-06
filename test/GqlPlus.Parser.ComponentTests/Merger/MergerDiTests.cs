using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Merger;

public class MergerDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "Merger";
}
