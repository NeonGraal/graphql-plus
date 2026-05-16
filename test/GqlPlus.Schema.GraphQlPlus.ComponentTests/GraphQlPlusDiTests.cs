using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public class GraphQlPlusDiTests(IServiceCollection services)
  : DiChecks(services)
{
  protected override string Label => "GraphQlPlus";
}
