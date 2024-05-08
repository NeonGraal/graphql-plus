using GqlPlus.Modelling;
using GqlPlus.Verifying;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddComponentTest()
      .AddVerifiers()
      .AddModellers();
}
