using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus.Merger;

public sealed class Startup : IConfiguresServices
{
  public static IServiceCollection Configure(IServiceCollection services)
    => services
      .AddComponentParsers();
}
