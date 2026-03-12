using GqlPlus.Matching;
using GqlPlus.Parsing;
using GqlPlus.Verifying;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddComponentParsers(false)
      .AddParsers(b => b
        .AddOperationParsers())
      .AddMatchers(b => b
        .ConstraintMatchers())
      .AddVerifiers(b => b
        .AddSchemaVerifiers()
        .AddOperationVerifiers());
}
