using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace GqlPlus;

public sealed class Startup : IConfiguresServices
{
  public static IServiceCollection Configure(IServiceCollection services)
    => services
      .AddComponentTest();
}
