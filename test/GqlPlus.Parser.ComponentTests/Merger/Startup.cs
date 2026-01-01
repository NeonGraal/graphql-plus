using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Merger;

public static class Startup
{
  public static void ConfigureServices(IServiceCollection services)
    => services
      .AddComponentParsers();
}
