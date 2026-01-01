using GqlPlus.Matching;
using GqlPlus.Parsing.Operation;
using GqlPlus.Verifying;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddComponentParsers(false)
      .AddOperationParsers()

      .AddFieldObjectKinds()
      .AddMatchers()
      .AddVerifiers();
}
